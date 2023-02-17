using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce; // the force with which the platform will bounce when broken
    [SerializeField] private float _bounceRadius; // the radius of the explosion effect when the platform is broken

    // This method is used to break the platform into segments and apply a bounce effect to each segment
    public void Break()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>(); // get an array of all the PlatformSegment components in this object's children

        // iterate through each segment and apply a bounce effect to it
        foreach (var segment in platformSegments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius); // apply the bounce effect
        }
    }
}
