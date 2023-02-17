using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset; // the offset of the camera direction from the beam direction
    [SerializeField] private float _lenght; // the distance between the camera and the ball

    private Ball _ball; // reference to the Ball object
    private Beam _beam; // reference to the Beam object
    private Vector3 _cameraPosition; // the position of the camera
    private Vector3 _minimumBallPosition; // the minimum position of the ball

    private void Start()
    {
        _ball = FindObjectOfType<Ball>(); // get a reference to the Ball object in the scene
        _beam = FindObjectOfType<Beam>(); // get a reference to the Beam object in the scene

        _cameraPosition = _ball.transform.position; // set the initial camera position to be the same as the ball's position
        _minimumBallPosition = _ball.transform.position; // set the initial minimum ball position to be the same as the ball's position

        TrackBall(); // track the ball's position
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y) // check if the ball has moved lower than the minimum position
        {
            TrackBall(); // track the ball's position
            _minimumBallPosition = _ball.transform.position; // update the minimum ball position
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position; // get the position of the beam
        beamPosition.y = _ball.transform.position.y; // set the y position of the beam to be the same as the ball's y position
        _cameraPosition = _ball.transform.position; // set the camera position to be the same as the ball's position
        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset; // calculate the direction of the camera
        _cameraPosition -= direction * _lenght; // calculate the camera position using the direction and length
        transform.position = _cameraPosition; // set the camera's position
        transform.LookAt(_ball.transform); // make the camera look at the ball
    }
}
