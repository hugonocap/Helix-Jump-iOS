using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public LayerMask ground;

	private const float jumpForce = 10;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	

	private void OnTriggerEnter(Collider other)
	{
		if (LevelController.instance.gameOver)
			return;

		if (((1 << other.gameObject.layer) & ground) == 0)
		{
			return;
		}


		rb.velocity = Vector3.zero;
		rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}

	public void GameOver()
	{
		rb.velocity = Vector3.zero;
		rb.useGravity = false;
	}

}
