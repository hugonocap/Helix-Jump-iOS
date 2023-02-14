using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour {

	public float speed = 10;
	public float offsetMove = -32;

	public Transform[] cylinders;

	private ScoreTrigger[] scores;

	bool swipe = false;
	float startXPos = 0;

	private void Awake()
	{
		scores = GetComponentsInChildren<ScoreTrigger>();
	}

	// Use this for initialization
	void Start () {

		RandomRotation();
	}
	
	// Update is called once per frame
	void Update () {

		if (LevelController.instance.gameOver)
			return;

		Rotate();

	}

	void Rotate()
	{
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{

			if (Input.touchCount == 1)
			{
				if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary)
				{
					startXPos = Input.GetAxis("Mouse X");
					swipe = true;
				}
				else if (Input.GetTouch(0).phase == TouchPhase.Ended)
				{
					swipe = false;
				}

				if (swipe)
				{
					transform.Rotate(new Vector3(0, (Input.GetAxis("Mouse X") - startXPos) * -1, 0) * speed * Time.deltaTime);
				}
			}

			
		}
		else
		{
			if (Input.GetMouseButton(0))
			{
				transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * -1, 0) * speed * Time.deltaTime);
			}
		}
		
			
	}

	void RandomRotation()
	{
		for (int i = 0; i < cylinders.Length; i++)
		{
			cylinders[i].rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
		}
	}

	public void Reposition(float yPos)
	{
		transform.position = new Vector3(transform.position.x, transform.position.y + yPos, transform.position.z);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			for (int i = 0; i < scores.Length; i++)
			{
				scores[i].SetColliders(true);
			}
			Reposition(offsetMove);
			RandomRotation();
		}
	}
}
