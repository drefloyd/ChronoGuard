using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject dronePrefab; 

    public Transform purpleSpawn;
    public Transform greenSpawn;
    public Transform yellowSpawn;

    public float spawnInterval = .4f; // Time interval between drone spawns.
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
        int spawnChooser = Random.Range(0, 3);

        if (spawnChooser == 0)
        {
            Instantiate(dronePrefab, purpleSpawn.position, purpleSpawn.rotation);
        }
        else if(spawnChooser == 1)
        {
            Instantiate(dronePrefab, greenSpawn.position, greenSpawn.rotation);
        }
        else
        {
            Instantiate(dronePrefab, yellowSpawn.position, yellowSpawn.rotation);
        }
    }
}
