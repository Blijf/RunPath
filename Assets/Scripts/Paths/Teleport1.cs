using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour {

public GameObject portal;
GameObject player;

	void Start ()
	{
		player= GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () 
	{
		
	}

	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			StartCoroutine(teleport());
		}
	}

	IEnumerator teleport()
	{
		yield return new WaitForSeconds(0f);
		player.transform.position= new Vector2 (portal.transform.position.x,portal.transform.position.y);
	}
}

