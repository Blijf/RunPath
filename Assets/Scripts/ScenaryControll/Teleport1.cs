using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour {

public GameObject portal;
public GameObject deadZoneCamera;
GameObject player;
BallForwardController ballForwardController;



	void Start ()
	{
		player= GameObject.FindGameObjectWithTag("Player");
		ballForwardController=player.GetComponent<BallForwardController>();

	}
	
	void Update () 
	{
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			//desactivamos el movimiento y la zona de muerte de la cámara
			ballForwardController.enabled=false;
			deadZoneCamera.SetActive(false);
			StartCoroutine(teleport());
		}
	}

	IEnumerator teleport()
	{
		yield return new WaitForSeconds(1f);
		player.transform.position= new Vector2 (portal.transform.position.x,portal.transform.position.y);
		ballForwardController.enabled=true;
		deadZoneCamera.SetActive(true);
		

	}
}

