using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipeScript : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;

    private void Awake()
    {
        //Stop moving on death
        FlyScript.deathEvent += () =>
        {
            speed = 0;
        };
    }

    void Update()
    {
        transform.position += Vector3.left * (speed * Time.deltaTime);
    }
}
