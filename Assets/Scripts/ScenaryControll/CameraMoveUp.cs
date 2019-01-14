using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveUp : MonoBehaviour 
{

	public float speed ;
	void Start () 
	{
		
	}
	
	void FixedUpdate () 
	{
		//movimiento ascendente de la cámara
		transform.Translate(Vector2.up*speed*Time.fixedDeltaTime);
	}
}
