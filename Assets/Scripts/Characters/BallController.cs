using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour 
{

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
    public float speed;         
	public enum direction {Up, Down,Left,Right}  
    private Rigidbody2D rb2d;       
	private float moveHorizontal;
	Vector2 inDirection, inNormal,outDirection; //fijarme en el esquema de los vectores de colisión 

//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------

	void Start () 
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
		//Dirección del player al iniciar la partida
		inDirection.Set(0,1);
	}
	


	void Update()
	{
		//movimiento
		 moveHorizontal = InputManager.MainHorizontal();

	}

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
		move();
	}

	private void OnCollisionEnter2D(Collision2D other) 
	{
		inNormal=other.contacts[0].normal;
		outDirection= Vector2.Reflect(inDirection,inNormal);
		inDirection=outDirection;
	
		Debug.Log(inDirection.normalized);

	}
//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void move()
	{
		rb2d.velocity= inDirection.normalized*speed*Time.deltaTime;
	}
}
