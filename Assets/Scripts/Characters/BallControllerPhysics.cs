using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControllerPhysics : MonoBehaviour 
{

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
	[Header("Características")]
    public float speed;             //Floating point variable to store the player's movement speed.
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
		currentUpSpeed=speed;
	}
	

	void Update()
	{
		//movimiento
		moveHorizontal = InputManager.MainHorizontal();
		moveVertical = InputManager.MainVertical();

	}

    void FixedUpdate()
    {
		move();
	}
	
	//TRIGGERS
	void OnTriggerExit2D(Collider2D other)
	{
		
			if(other.gameObject.CompareTag("Scenary"))
			{
				GameController.isDead=true;
				Debug.Log("Esta muerto, onExit");
			}

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Scenary"))
		{
			GameController.isDead=false;
			Debug.Log("Esta vivo, onStay");
		}
	}
//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void move()
	{

		if(moveHorizontal!=0f || moveVertical!=0f || joystick.Horizontal!=0f|| joystick.Vertical!=0f)
		{
			vectorMove.Set(joystick.Horizontal+moveHorizontal,joystick.Vertical+moveVertical);//la y es 0 ya que no se movera verticalmente

			// Debug.Log("Joystick H: "+joystick.Horizontal+"-Joystick V: "+joystick.Vertical);
			vectorMove=vectorMove.normalized*speed*Time.fixedDeltaTime;

			rb2d.AddForce(vectorMove);
		}
		
	}
}
