using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundspawner;
    private PlayerController playerController; // Reference to the PlayerController script

    public GameObject[] obstaclePrefabs;
    public Transform[] spawnpoints;

    private void Awake()
    {
        groundspawner = GameObject.FindObjectOfType<GroundSpawner>();
        playerController = GameObject.FindObjectOfType<PlayerController>(); // Get reference to PlayerController
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawnobs();
    }

    private void OnTriggerExit(Collider other)
    {
        groundspawner.SpawnTile();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawnobs()
    {
        int ChooseSpawnPoint = Random.Range(0, spawnpoints.Length - 3);
        int SpawnPrefab = Random.Range(0, obstaclePrefabs.Length - 1);

        Instantiate(obstaclePrefabs[SpawnPrefab], spawnpoints[ChooseSpawnPoint].transform.position, Quaternion.identity, transform);

        // Accessing the Score variable from PlayerController
        long score = playerController.Score;
        // Debug.Log("Score from PlayerController: " + score);
        if (score % 5 == 0 && score != 0)
        {
            int ChooseDragonSpawnPoint = Random.Range(7, spawnpoints.Length - 1);//
            int DragonSpawnPrefab = obstaclePrefabs.Length - 1;

            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            Instantiate(obstaclePrefabs[DragonSpawnPrefab], spawnpoints[ChooseDragonSpawnPoint].transform.position, rotation);
        }
    }
}
