using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public Vector3 offset; // Offset between the camera and the player


    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
    }
    private void Start()
    {
        offset = transform.position - playerTransform.position;
    }
    void Update()
    {
        Vector3 targetPosition = playerTransform.position + offset;
        // targetPosition.x = 0;
        transform.position = targetPosition;
    }
}
