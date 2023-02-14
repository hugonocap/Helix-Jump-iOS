using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour {

	public Collider[] colliders;


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			//score
			LevelController.instance.SetScore();
			SetColliders(false);
		}
	}

	public void SetColliders(bool state)
	{
		for (int i = 0; i < colliders.Length; i++)
		{
			colliders[i].enabled = state;
		}
	}
}
