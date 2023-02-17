using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Require a Rigidbody component on the same GameObject as this script
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce; // the force with which the ball will jump when it hits a platform
    private Rigidbody _rigidbody; // reference to the ball's Rigidbody component

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); // get the ball's Rigidbody component
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment)) // check if the object collided with has a PlatformSegment component
        {
            _rigidbody.velocity = Vector3.zero; // set the ball's current velocity to zero
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); // apply an upward impulse force to the ball
        }
    }
}
