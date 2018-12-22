using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerPhysics : MonoBehaviour 
{

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
	[Header("Características")]
    public float speedUpStart;             //Floating point variable to store the player's movement speed.
    public float speedHorizontal;             //Floating point variable to store the player's movement speed.
	[Header("Otros")]
	protected Joystick joystick;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private float moveHorizontal,moveVertical,currentUpSpeed;
	Vector2 vectorMove;
	Quaternion quartenionRot;


//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------

	void Start () 
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();

		joystick= FindObjectOfType<Joystick>();
		currentUpSpeed=speedUpStart;
	}
	


	void Update()
	{
		//movimiento
		moveHorizontal = InputManager.MainHorizontal();
		moveVertical = InputManager.MainVertical();

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

		// if(moveHorizontal!=0f || moveVertical!=0f || joystick.Horizontal!=0f|| joystick.Vertical!=0f)

			vectorMove.Set(joystick.Horizontal+moveHorizontal,currentUpSpeed);//la y es 0 ya que no se movera verticalmente
			if(moveHorizontal!=0f || joystick.Horizontal!=0 )
			{
				currentUpSpeed=0.0f;
			}
			else
			{
				currentUpSpeed=speedUpStart;
			}
			// vectorMove.Set(speedHorizontal*(joystick.Horizontal+moveHorizontal),speedUp);//la y es 0 ya que no se movera verticalmente

			// Debug.Log("Joystick H: "+speedHorizontal*(joystick.Horizontal+moveHorizontal)+"Joystick H: "+speedUp*Time.fixedDeltaTime);
			vectorMove=vectorMove.normalized*Time.fixedDeltaTime;	
			rb2d.AddForce(vectorMove);
		
	}
}
