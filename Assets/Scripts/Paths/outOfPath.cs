using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outOfPath : MonoBehaviour {

	string lastCollider;
	//TRIGGERS
	void OnTriggerExit2D(Collider2D other)
	{
		//Si sale del camino y ademas no esta en otro camino
		if(other.gameObject.CompareTag("Player")&&this.name==lastCollider)
		{
			
			GameController.isDead=true;
			Debug.Log("DEAD!, FUERA DESDE: "+ this.name);
		}

	}

	void OnTriggerStay2D(Collider2D other)
	{
		lastCollider=this.name;
		if(other.gameObject.CompareTag("Player"))
		{
			GameController.isDead=false; 
			Debug.Log("ALIVE!, ESTA EN: "+ this.name);
		}
	}
}
