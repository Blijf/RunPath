using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallForwardForceController : MonoBehaviour 
{

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
	[Header("Parámetros de Velocidad")]
    public float accelerationVertical;
    public float accelerationHorizontal;
	
	[Header("Otros")]
	public Text countDownText; 
	//_________________________________________________________
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private float horizontal, vertical;
	private Vector2 vectorMove, direction, startPos;
	string message;
	private Vector3 mobileDir= Vector3.zero;
	private Quaternion quartenionRot;
	private float screenWidth;
	public static string currentFloor;
	

//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------

	void Start () 
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
		//Tamaño del screen 
		screenWidth=Screen.width;
	} 	
	
	void Update()
	{
		whereInputs();
	}

    void FixedUpdate()
    {
		// Debug.Log("direction_vector "+horizontal );
		// Debug.Log("acceleration_vector"+mobileDir);
		// Debug.Log("touch "+ message);
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

	// void OnCollisionStay2D(Collision2D other) 
	// {
	// 	//cuando se produce una colisión deja de avanzar
	// 	if(currentUpSpeed>=0)
	// 	currentUpSpeed-=speedreductionToCollision;

	// 	//le damos un plus a la velocidad horizontal
	// }


	// void OnCollisionExit2D(Collision2D other)
	// {
	// 	if(currentUpSpeed<=speedVertical)
	// 	{
	// 		currentUpSpeed+=speedreductionToCollision;
	// 	}
	// }

	//TRIGGERS
	// _______________________________________
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
	//MOVIMIENTO
	//_______________________________________________________________________________
	private void move()
	{
		// countDownText.enabled=false;//cuando se mueve desactivamos el texto de la cuenta atras
		//...............................
		//VARIACIÓN DE LOS VECTORES
		//................................
		vectorMove.Set(horizontal*accelerationHorizontal,accelerationVertical);
		vectorMove=vectorMove*Time.fixedDeltaTime;

		//...............................
		//MÉTODOS FÍSICAS
		//................................
		rb2d.AddForce(vectorMove);
	}

	//INPUTS 
	//_______________________________________________________________________________
	//INPUTS Detectamos de que plataforma procede la acción de movimiento del usuario.
	private void whereInputs()
	{
		//Check if we are running either in the Unity editor or in a standalone build.
		#if UNITY_STANDALONE || UNITY_WEBPLAYER
			//movimiento
			horizontal = InputManager.MainHorizontal();
			vertical = InputManager.MainVertical();
		//Check if we are running on iOS, Android, Windows Phone 8 or Unity iPhone
		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
			// horizontal = InputManager.MainHorizontal();
			// swipeJoystick();
			// accelerationJoystick();
			splitScreenJoystick();

		#endif //End of mobile platform dependendent compilation section started above with #elif

	}

	//SWYPE
	void swipeJoystick()
	{
		// Track a single touch as a direction control.
		if (Input.touchCount > 0)
		{

			// Touch touch = Input.GetTouch(0);

			foreach (Touch touch in Input.touches)
			{
					// Handle finger movements based on TouchPhase
					switch (touch.phase)
					{
						//When a touch has first been detected, change the message and record the starting position
						case TouchPhase.Began:
							// Record initial touch position.
							startPos = touch.position;
							message = "Begun ";
							break;

						//Determine if the touch is a moving touch
						case TouchPhase.Moved:
							// Determine direction by comparing the current touch position with the initial one
							direction = touch.position - startPos;
							if(direction.x>0)
							{
								direction.Set(0.5f,0f);
							}
							else
							{
								direction.Set(-0.5f,0f);
							}
							
							message = "Moving ";
							break;

						case TouchPhase.Ended:
							// Report that the touch has ended when it ends
							direction.Set(.0f,.0f);
							message = "Ending ";
							break;

						// case TouchPhase.Stationary:
						// 	// A finger is touching the screen but hasn't moved.
						// 	direction.Set(.0f,.0f);
						// 	message = "Ending ";
						// 	break;
					}
					// direction=direction.normalized;
					horizontal= direction.x;
			}
		}
	}

	//ACCELERATION
	void accelerationJoystick()
	{
		mobileDir = Input.acceleration; 
		// clamp acceleration vector to unit sphere
		if(mobileDir.sqrMagnitude>1)
		{
			mobileDir.Normalize();
		}
		// mobileDir*=2;
		horizontal= mobileDir.x;
	}

	//SPLIT SCREEN
	void splitScreenJoystick()
	{
		foreach (Touch touch in Input.touches)
		{
			//der
			if(touch.position.x>screenWidth/2)
			{
				direction.Set(0.5f,0f);
			}
			//izq
			if(touch.position.x<screenWidth/2)
			{
				direction.Set(-0.5f,0f);
			}

			switch (touch.phase)
			{
				case TouchPhase.Ended:
				// Report that the touch has ended when it ends
				direction.Set(.0f,.0f);
				message = "Ending ";
				break;
			}
		}
		horizontal= direction.x;

	}
}	
