using System.Diagnostics.Tracing;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    // public GameObject groundTilePrefab; // This variable stores the prefab of the ground tile that will be spawned
    public GameObject[] Grounds;
    private int groundStack = 3;
    private int chooseGround = 0;
    Vector3 nextSpawnPoint; // This variable stores the position of the next ground tile that will be spawned

    public void SpawnFirstGround(){
        GameObject tempGround = Instantiate(Grounds[0], nextSpawnPoint, Quaternion.identity); // This line creates a new instance of the ground tile prefab at the nextSpawnPoint position and with the default rotation (Quaternion.identity)
        // nextSpawnPoint = tempGround.transform.GetChild(1).transform.position; // This line updates the nextSpawnPoint to the position of the child object with index 1 of the newly spawned ground tile
        nextSpawnPoint = new Vector3(tempGround.transform.GetChild(1).transform.position.x,tempGround.transform.GetChild(1).transform.position.y,tempGround.transform.GetChild(1).transform.position.z+73); // This line updates the nextSpawnPoint to the position of the child object with index 1 of the newly spawned ground tile
    }
    public void SpawnRandomGround()
    {
        if (groundStack == 0)
        {
            chooseGround = Random.Range(0, Grounds.Length);
            groundStack = 3;
        }
        groundStack--;
        // This function is called to spawn a new ground tile
        GameObject tempGround = Instantiate(Grounds[chooseGround], nextSpawnPoint, Quaternion.identity); // This line creates a new instance of the ground tile prefab at the nextSpawnPoint position and with the default rotation (Quaternion.identity)
        nextSpawnPoint = new Vector3(tempGround.transform.GetChild(1).transform.position.x,tempGround.transform.GetChild(1).transform.position.y,tempGround.transform.GetChild(1).transform.position.z+73); // This line updates the nextSpawnPoint to the position of the child object with index 1 of the newly spawned ground tile
    }

    void Start()
    {
        // This function is called once when the script is first loaded
        for (int i = 0; i < groundStack; i++)
        {
            SpawnFirstGround(); // This line calls the SpawnTile function 10 times to spawn 10 ground tiles
        }
    }
}
