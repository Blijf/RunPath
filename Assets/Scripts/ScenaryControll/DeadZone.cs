using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			GameController.isDead=true;
		}
	}
}
