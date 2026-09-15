using System;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [Tooltip("References")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject objectToSpawn;

    System.Random rand = new System.Random();

    [Tooltip("Movement Variables")]
    bool movingUp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ShootParticle();
    }

    void Movement()
    {
        if (rand.Next(0,21) < 10)
        {
            movingUp = true;
        }
        else
        {
            movingUp = false;
        }
    }

    void ShootParticle()
    {

    }
}
