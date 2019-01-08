using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour 
{

//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
    public float speed;         
	public enum Direction {Up, Down,Left,Right}  
    private Rigidbody2D rb2d;       
	private float moveHorizontal,moveVertical;
	Vector2 inDirection, inNormal,outDirection; //fijarme en el esquema de los vectores de colisión 

	float angleDirection;
//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------

	void Start () 
	{
		//Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
		//Dirección del player al iniciar la partida
		inDirection.Set(1,0);
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

	private void OnCollisionEnter2D(Collision2D other) 
	{
		inNormal=other.contacts[0].normal;
		outDirection= Vector2.Reflect(inDirection,inNormal);

		inDirection=outDirection;


		Debug.Log(angleDirection);

	}
//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void move()
	{
		//Cuando se mueve el player no afecta el rebote.
		if(moveHorizontal!=0||moveVertical!=0)
		{
			//Añadimos el movimiento horizontal del jugador
			inDirection.Set(moveHorizontal,moveVertical);
		}
		// rb2d.velocity= inDirection.normalized*speed*Time.deltaTime;
		rb2d.AddForce(inDirection*speed*Time.deltaTime);
		// transform.rotation = Quaternion.LookRotation(inDirection,Vector3.back);
	}
}
