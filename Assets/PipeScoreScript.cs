using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScoreScript : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreManagerScript.Instance.UpdateScore();
        if (audioSource)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}