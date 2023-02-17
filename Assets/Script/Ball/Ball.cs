using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // This method is called when the ball enters a trigger collider.
    private void OnTriggerEnter(Collider other)
    {
        // Try to get a PlatformSegment component from the collided object.
        if (other.TryGetComponent(out PlatformSegment platformSegment))
        {
            // Get the parent platform of the platform segment, and call the Break() method on it.
            other.GetComponentInParent<Platform>().Break();
        }
    }
}
