using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // ensures that a Rigidbody is attached to this game object
public class PlatformSegment : MonoBehaviour
{
    // This method is used to apply a bounce effect to the platform segment
    public void Bounce(float force, Vector3 centre, float radius)
    {
        // Try to get the attached Rigidbody component
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.isKinematic = false; // disable kinematic mode on the Rigidbody so it can be affected by physics
            rigidbody.AddExplosionForce(force, centre, radius); // apply an explosion force to the Rigidbody
        }
    }
}
