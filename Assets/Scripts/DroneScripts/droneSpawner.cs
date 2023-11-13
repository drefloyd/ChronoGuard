using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject dronePrefab; 
    public Transform spawnPoint;   

    public float spawnInterval = 2f; // Time interval between drone spawns.
    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        // Check if it's time to spawn a drone
        if (Time.time >= nextSpawnTime)
        {
            SpawnDrone();

            // Update the next spawn time
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnDrone()
    {
        Instantiate(dronePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
