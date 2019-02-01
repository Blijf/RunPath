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
	Vector2 vectorMove, vectorMoveH;
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

	void OnCollisionEnter2D(Collision2D other)
	{
	// 	//cuando se produce una colisión deja de avanzar
	// 	currentUpSpeed=.0f;
		
		//Se reproduce el sonido donde ha colisionado
		AudioSource audio= other.gameObject.GetComponent<AudioSource>();
		if(audio!=null)
		{
			audio.Play();
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Se reproduce el sonido donde ha entrado.
		AudioSource audio= other.gameObject.GetComponent<AudioSource>();
		if(audio!=null)
		{
			audio.Play();
		}
	}
	
//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void move()
	{
		// countDownText.enabled=false;//cuando se mueve desactivamos el texto de la cuenta atras
		
		// currentUpSpeed=speedVertical;
		// vectorMove.Set(moveHorizontal*speedHorizontal,currentUpSpeed);
		vectorMove.Set(0.0f,currentUpSpeed);
		vectorMoveH.Set(moveHorizontal*speedHorizontal*1000,0.0f);

		vectorMove=vectorMove*Time.fixedDeltaTime;
		vectorMoveH=vectorMoveH*Time.fixedDeltaTime;

		// rb2d.velocity= vectorMove;
		rb2d.MovePosition(rb2d.position+vectorMove);
		rb2d.AddForce(vectorMoveH);
	}
}
