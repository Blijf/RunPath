using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallFullControllerPhysics : MonoBehaviour 
{

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
	[Header("Características")]
    public float speed;             //Floating point variable to store the player's movement speed.
	
	[Header("Otros")]
	public Text countDownText; 
	//_________________________________________________________
	protected Joystick joystick;
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private float moveHorizontal,moveVertical,currentUpSpeed;
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
	

	void OnTriggerEnter2D(Collider2D other)
	{
		currentFloor= other.gameObject.name;

	}
//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void move()
	{


		if(joystick==null)
		{
			if(moveHorizontal!=0f || moveVertical!=0f )
			{
				countDownText.enabled=false;//cuando se mueve desactivamos el texto de la cuenta atras

				vectorMove.Set(moveHorizontal,moveVertical);//la y es 0 ya que no se movera verticalmente

				// Debug.Log("Joystick H: "+joystick.Horizontal+"-Joystick V: "+joystick.Vertical);
				vectorMove=vectorMove.normalized*speed*Time.fixedDeltaTime;

				rb2d.AddForce(vectorMove);
			}
		}
		else
		{
			
			if(moveHorizontal!=0f || moveVertical!=0f || joystick.Horizontal!=0f|| joystick.Vertical!=0f)
			{
				countDownText.enabled=false;//cuando se mueve desactivamos el texto de la cuenta atras

				vectorMove.Set(joystick.Horizontal+moveHorizontal,joystick.Vertical+moveVertical);//la y es 0 ya que no se movera verticalmente

				// Debug.Log("Joystick H: "+joystick.Horizontal+"-Joystick V: "+joystick.Vertical);
				vectorMove=vectorMove.normalized*speed*Time.fixedDeltaTime;

				rb2d.AddForce(vectorMove);
			}
		}

		
	}
}
