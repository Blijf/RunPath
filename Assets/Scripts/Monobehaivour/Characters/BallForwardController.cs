using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallForwardController : MonoBehaviour 
{

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
	[Header("Parámetros de Velocidad")]
    public float speedVertical=10;
    public float speedHorizontalMax=9;
    public float speedHorizontal=1;
	public float speedreductionToCollision=0.25f;
	public float accelerationHorizontal=0.75f;
	
	[Header("Otros")]
	public Text countDownText; 
	//_________________________________________________________
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private float moveHorizontal,currentUpSpeed, currentHSpeed;
	Vector2 vectorMove, vectorMoveForce;
	Quaternion quartenionRot;
	public static string currentFloor;
	public Item item;
	private Inventory inventory;

//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------

	void Start () 
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
		currentUpSpeed= speedVertical;
		currentHSpeed= speedHorizontal;
	} 	
	

	void Update()
	{
		//movimiento
		moveHorizontal = InputManager.MainHorizontal();

	}

    void FixedUpdate()
    {
		// Debug.Log("V: "+ currentUpSpeed);
		// Debug.Log("H: "+ currentHSpeed);
		move();
	}
	
	//COLLISIONS
	// _______________________________________
	void OnCollisionEnter2D(Collision2D other)
	{
		
		//Se reproduce el sonido donde ha colisionado
		AudioSource audio= other.gameObject.GetComponent<AudioSource>();
		if(audio!=null)
		{
			audio.Play();
		}

	}
	//TRIGGERS
	// _______________________________________
	void OnTriggerEnter2D(Collider2D other)
	{
		//HABILIDADES
		switch(other.gameObject.name)
		{
			case "Life":
					inventory.addItem(item);
			break;

		}

		//AUDIOS. Se reproduce el sonido donde ha entrado.
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
		
		//...............................
		//VARIACIÓN DE LOS VECTORES
		//................................

		//Se aumenta le velocidad INCREMENTALMENTE
		if(moveHorizontal!=0)
		{
			//limitar la velocidad
			if(currentHSpeed<=speedHorizontalMax)
			currentHSpeed+=accelerationHorizontal;
		}
		else
		{
			currentHSpeed=speedHorizontal;
		}
		vectorMove.Set(moveHorizontal*currentHSpeed,currentUpSpeed);
		vectorMove=vectorMove*Time.fixedDeltaTime;

		//...............................
		//MÉTODOS FÍSICAS
		//................................
		// rb2d.velocity= vectorMove;
		rb2d.MovePosition(rb2d.position+vectorMove);
		// rb2d.AddForce(vectorMoveForce,ForceMode2D.Force);
	}
}
