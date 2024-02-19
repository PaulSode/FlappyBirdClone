using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeManagerScript : MonoBehaviour
{
    public static PipeManagerScript Instance;
    
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject pipe;

    [SerializeField] private AudioSource audioSource;

    private float _timer = 0f;
    private bool _flapped = false;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void BeginSpawnCycle()
    {
        SpawnPipe();
        _flapped = true;
    }

    private void Update()
    {
        if (_flapped)
        {
            if (_timer >= maxTime)
            {
                SpawnPipe();
                _timer = 0;
            }

            _timer += Time.deltaTime;
        }
    }

    private void SpawnPipe()
    {
        var spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        GameObject spawnedPipe = Instantiate(pipe, spawnPos, Quaternion.identity);
        spawnedPipe.GetComponent<PipeScoreScript>().audioSource = audioSource;
        
        Destroy(spawnedPipe, 10f);
    }
}
