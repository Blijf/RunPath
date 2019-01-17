using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallForwardController : MonoBehaviour 
{

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
	[Header("Características")]
    public float speedVertical;
    public float speedHorizontal;
	
	[Header("Otros")]
	public Text countDownText; 
	//_________________________________________________________
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private float moveHorizontal,currentUpSpeed;
	Vector2 vectorMove;
	Quaternion quartenionRot;
	public static string currentFloor;

//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------

	void Start () 
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
		currentUpSpeed= speedVertical;
	} 	
	

	void Update()
	{
		//movimiento
		moveHorizontal = InputManager.MainHorizontal();

	}

    void FixedUpdate()
    {
		move();
	}
	

	// void OnTriggerEnter2D(Collider2D other)
	// {
	// 	currentFloor= other.gameObject.name;

	// }

	// void OnCollisionEnter2D(Collision2D other)
	// {
	// 	//cuando se produce una colisión deja de avanzar
	// 	currentUpSpeed=.0f;

	// }
	
//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void move()
	{
		// countDownText.enabled=false;//cuando se mueve desactivamos el texto de la cuenta atras
		
		// currentUpSpeed=speedVertical;
		vectorMove.Set(moveHorizontal*speedHorizontal,currentUpSpeed);//la y es 0 ya que no se movera verticalmente

		vectorMove=vectorMove*Time.fixedDeltaTime;

		// rb2d.velocity= vectorMove;
		rb2d.MovePosition(rb2d.position+vectorMove);
		// rb2d.AddForce(vectorMove);
	}
}
