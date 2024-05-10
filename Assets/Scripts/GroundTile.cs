using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    private GroundSpawner groundspawner;
    private PlayerController playerController; // Reference to the PlayerController script
    public GameObject coinprefab;

    public GameObject[] obstaclePrefabs;
    public GameObject[] FlyPrefabs;
    public Transform[] spawnpoints;
    public Transform[] Flyspawnpoints;
    private void Awake()
    {
        groundspawner = GameObject.FindObjectOfType<GroundSpawner>();
        playerController = GameObject.FindObjectOfType<PlayerController>(); // Get reference to PlayerController
    }

    // Start is called before the first frame update
    void Start()
    {
        Spawnobs();
        Spawncoin();
    }

    private void OnTriggerExit(Collider other)
    {
        if (playerController.isAlive)
        {
            groundspawner.SpawnRandomGround();
            Destroy(gameObject, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawnobs()
    {
        int ChooseSpawnPoint = Random.Range(0, spawnpoints.Length);
        int SpawnPrefab = Random.Range(0, obstaclePrefabs.Length);//can get error (add -1)

        Instantiate(obstaclePrefabs[SpawnPrefab], spawnpoints[ChooseSpawnPoint].transform.position, Quaternion.identity, transform);

        // Accessing the Score variable from PlayerController
        long score = playerController.CoinScore;
        // Debug.Log("Score from PlayerController: " + score);
        if (score % 5 == 0 && score != 0)//spawn Flying dinosaur
        {
            int ChooseFlySpawnPoint = Random.Range(0, Flyspawnpoints.Length);
            int SpawnFlyPrefab = Random.Range(0, FlyPrefabs.Length);//can get error (add -1)

            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            Instantiate(FlyPrefabs[SpawnFlyPrefab], spawnpoints[ChooseFlySpawnPoint].transform.position, rotation);
        }
        // //if (score % 5 == 0 && score != 0)//spawn Ai Trex
        // {
        //     // int ChooseFlySpawnPoint = Random.Range(7, spawnpoints.Length - 1);
        //     // int FlySpawnPrefab = obstaclePrefabs.Length - 1;

        //     // Quaternion rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        //     if (spawnpoints[^1].transform.position.z < playerController.transform.position.z)
        //         Instantiate(obstaclePrefabs[^1], spawnpoints[^1].transform.position, Quaternion.identity);
        // }
    }
    public void Spawncoin()
    {
        int spawnamount = 3;
        for (int i = 0; i < spawnamount; i++)
        {
            GameObject tempcoin = Instantiate(original: coinprefab);
            tempcoin.transform.position = SpawnRandomPoint(GetComponent<Collider>());

        }
    }
    Vector3 SpawnRandomPoint(Collider x)
    {
        Vector3 point = new Vector3(Random.Range(x.bounds.min.x, x.bounds.max.x), Random.Range(x.bounds.min.y, x.bounds.max.y), Random.Range(x.bounds.min.z, x.bounds.max.z));
        point.y = 7;
        return point;
    }
}
