using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceArrow : MonoBehaviour
{
    public Transform playerCamera; // Reference to the player's camera
    public Transform target; // The point of interest for the arrow to hover above, used to keep the arrow above the object.
    private Vector3 offset = new Vector3(0f, 0.3f, 0f); // The position offset, used in the position calculation, in order to keep the arrow above the point of interest.

    private void Update()
    {
        // Make the arrow face the camera
        if (playerCamera != null)
        {
            transform.LookAt(transform.position + playerCamera.forward);
        }

        // Make the arrow hover above the point of interest
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }

    public void Delete() // Function to be triggered through the point of interest's Select Entered interactable event, which deletes the guidance arrow once the user has gotten hold of the item.
    {
        gameObject.SetActive(false);
    }
}
