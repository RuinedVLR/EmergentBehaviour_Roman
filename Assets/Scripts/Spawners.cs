using System;
using UnityEngine;

public class Spawners : MonoBehaviour
{
    [Tooltip("References")]
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnRate = 1f;
    [SerializeField] MovementDir movementDir;

    [Tooltip("Projectile List")]
    [SerializeField] GameObject[] projectileList;

    [Tooltip("Movement Variables")]
    [SerializeField] int spawnerMaxRange;
    [SerializeField] int spawnerMinRange;

    System.Random rand = new System.Random();

    public enum MovementDir
    {
        Up,
        Down,
        Left,
        Right
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        spawnRate += Time.deltaTime;

        if (spawnRate >= 1f)
        {
            ShootParticle();
            spawnRate = 0f;
        }
    }

    void Movement()
    {

    }

    void ShootParticle()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, (float)rand.NextDouble() * (spawnerMaxRange - spawnerMinRange) + spawnerMinRange);

        GameObject spawnedObject = Instantiate(projectileList[rand.Next(projectileList.Length)], spawnPoint.position, Quaternion.identity);

        Vector2 forceDirection = Vector2.zero;
        switch (movementDir)
        {
            case MovementDir.Up:
                forceDirection = Vector2.up;
                break;
            case MovementDir.Down:
                forceDirection = Vector2.down;
                break;
            case MovementDir.Left:
                forceDirection = Vector2.left;
                break;
            case MovementDir.Right:
                forceDirection = Vector2.right;
                break;
        }

        spawnedObject.GetComponent<Rigidbody2D>().AddForce(forceDirection * 5f, ForceMode2D.Impulse);
    }
}
