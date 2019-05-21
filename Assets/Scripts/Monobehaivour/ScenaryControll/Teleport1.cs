using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour {

public GameObject portal;
public GameObject deadZoneCamera;
GameObject player;
BallForwardForceController ballForwardForceController;



	void Start ()
	{
		player= GameObject.FindGameObjectWithTag("Player");
		ballForwardForceController=player.GetComponent<BallForwardForceController>();
	}
	
	void Update () 
	{
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject==player)
		{
			//desactivamos el movimiento y la zona de muerte de la cámara
			// ballForwardForceController.enabled=false; //se puede modificar la velocidad
			player.SetActive(false);
			deadZoneCamera.SetActive(false);
			StartCoroutine(teleport());
		}
	}

	IEnumerator teleport()
	{
		yield return new WaitForSeconds(0.05f);
		player.transform.position= new Vector2 (portal.transform.position.x,portal.transform.position.y);
		// ballForwardForceController.enabled=true; 
		player.SetActive(true);
		deadZoneCamera.SetActive(true);
		

	}
}

