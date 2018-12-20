using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
public float speed;
public Transform[]moveSpots;
public float distanceToSpot;
public float startWaitTime;
private float waitTime;//tiempo que tarda para buscar el siguiente punto
private int randomSpot;
//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------
	void Start () 
	{
		waitTime=startWaitTime;
		randomSpot= Random.Range(0,moveSpots.Length);
	}
	
	void Update () 
	{
		movement();
	}

//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void movement()
	{
		transform.position= Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position,speed*Time.deltaTime);

		if(Vector2.Distance(transform.position,moveSpots[randomSpot].position)<distanceToSpot)
		{
			if(waitTime<=0)
			{
				randomSpot= Random.Range(0,moveSpots.Length);
				waitTime=startWaitTime;
			}
			else
			{
				waitTime-=Time.deltaTime;
			}
		}
	}
}
