using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
    public float speedUp;             //Floating point variable to store the player's movement speed.
    public float speedHorizontal;             //Floating point variable to store the player's movement speed.
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private float moveHorizontal;


//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------

	void Start () 
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
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
//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void move()
	{
		transform.Translate( transform.up*speedUp*Time.fixedDeltaTime);
		if(moveHorizontal!=0f&&moveHorizontal>0)//derecha
		{
			transform.Translate( transform.right*speedHorizontal*Time.fixedDeltaTime);
		}
		if(moveHorizontal!=0f&&moveHorizontal<0)//izquierda
		{
			transform.Translate( -transform.right*speedHorizontal*Time.fixedDeltaTime);
		}
	}
}
