using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathController : MonoBehaviour {
	

// Si el objeto sale del camino muere
	private void OnTriggerExit2D(Collider2D other)
	{
		
		if(other.gameObject.CompareTag("Player"))
		{
			Debug.Log(" ha salido el player");
			GameController.isDead=true;
		}

	}
	
}
