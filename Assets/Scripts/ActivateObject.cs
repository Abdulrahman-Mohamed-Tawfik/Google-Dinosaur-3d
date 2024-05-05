using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject objectToToggle; // Reference to the object you want to activate/deactivate
    public bool activateObject; // Boolean variable to control activation state

    void Update()
    {
        // Check if the boolean variable is true
        if (activateObject)
        {
            // Activate the object if it's not already active
            if (!objectToToggle.activeSelf)
            {
                objectToToggle.SetActive(true);
            }
        }
        else
        {
            // Deactivate the object if it's not already inactive
            if (objectToToggle.activeSelf)
            {
                objectToToggle.SetActive(false);
            }
        }
    }
}
