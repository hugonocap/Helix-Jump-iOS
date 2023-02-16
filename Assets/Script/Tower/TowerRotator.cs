using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require a Rigidbody component to be attached to the same GameObject as this script
[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
    // Serialize this field so it can be edited in the inspector
    [SerializeField] private float _rotateSpeed;

    // Private reference to the Rigidbody component
    private Rigidbody _rigidbody;

    private void Start()
    {
        // Get a reference to the Rigidbody component
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if there are any touches on the screen
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);
            // Check if the touch has moved
            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the torque based on the touch's delta position and the rotation speed
                float torque = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                // Apply the torque to the Rigidbody component
                _rigidbody.AddTorque(Vector3.up * torque);
            }
        }
    }
}
