using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject robotGuardianPrefab;
    public GameObject robotInvaderPrefab;
    public GameObject robotRockiePrefab;

    public Transform purpleSpawn;
    public Transform greenSpawn;
    public Transform yellowSpawn;

    [SerializeField]
    public static float spawnInterval = 1.8f;
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
        int spawnChooser = Random.Range(0, 3); // 0,1,2
        int droneChooser = Random.Range(0, 3); // 0,1,2

        GameObject droneToSpawn;
        Quaternion? rotationToUse = null;

        Vector3 purpleTempPosition = purpleSpawn.position;
        Vector3 greenTempPosition = greenSpawn.position;
        Vector3 yellowTempPosition = yellowSpawn.position;

        if (droneChooser == 0)
        {
            droneToSpawn = robotGuardianPrefab;
            rotationToUse = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (droneChooser == 1)
        {
            droneToSpawn = robotInvaderPrefab;
            rotationToUse = Quaternion.Euler(0f, 180f, 0f); // invader and guardian both need unique rotations
        }
        else
        {
            droneToSpawn = robotRockiePrefab;
            rotationToUse = Quaternion.Euler(0f, 180f, 0f);
        }

        if (spawnChooser == 0)
        {
            if (droneToSpawn == robotRockiePrefab)
            {
                purpleSpawn.position += new Vector3(0f, 10f, 0f);   // invader and guardian spawn higher than neccessary
                Instantiate(droneToSpawn, purpleSpawn.position, (Quaternion)rotationToUse);
                purpleSpawn.position = purpleTempPosition;
            }
            else
            {
                purpleSpawn.position -= new Vector3(0f, 10f, 0f);   // invader and guardian spawn higher than neccessary
                Instantiate(droneToSpawn, purpleSpawn.position, (Quaternion)rotationToUse);
                purpleSpawn.position = purpleTempPosition;
            }
        }
        else if(spawnChooser == 1)
        {
            if (droneToSpawn == robotRockiePrefab)
            {
                greenSpawn.position += new Vector3(0f, 10f, 0f);
                Instantiate(droneToSpawn, greenSpawn.position, (Quaternion)rotationToUse);
                greenSpawn.position = greenTempPosition;
            }
            else
            {
                greenSpawn.position -= new Vector3(0f, 10f, 0f);
                Instantiate(droneToSpawn, greenSpawn.position, (Quaternion)rotationToUse);
                greenSpawn.position = greenTempPosition;
            }
        }
        else
        {
            if (droneToSpawn == robotRockiePrefab)
            {
                yellowSpawn.position += new Vector3(0f, 10f, 0f);
                Instantiate(droneToSpawn, yellowSpawn.position, (Quaternion)rotationToUse);
                yellowSpawn.position = yellowTempPosition;
            }
            else
            {
                yellowSpawn.position -= new Vector3(0f, 10f, 0f);
                Instantiate(droneToSpawn, yellowSpawn.position, (Quaternion)rotationToUse);
                yellowSpawn.position = yellowTempPosition;
            }
        }
    }
}
