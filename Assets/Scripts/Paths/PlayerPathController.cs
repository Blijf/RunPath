using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathController : MonoBehaviour {
	

// Si el objeto sale del camino muere
	private void OnTriggerExit2D(Collider2D other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			GameController.isDead=true;
			Debug.Log("Exit, player is dead"+GameController.isDead);
		}

	}
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			GameController.isDead=false;
			Debug.Log("Stay, player is dead"+GameController.isDead);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			GameController.isDead=false;
			Debug.Log("Enter, player is dead"+GameController.isDead);
		}
	}
	
}
