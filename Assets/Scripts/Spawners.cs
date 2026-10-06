using System;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [Tooltip("References")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject objectToSpawn;
    [SerializeField] float spawnRate = 1f;

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

        if (Time.time >= spawnRate)
        {
            ShootParticle();
            spawnRate = Time.time + 1f;
        }
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
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);

        spawnedObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
    }
}
