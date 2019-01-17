using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationAndRotation : MonoBehaviour {
    // User Inputs
	[Header("AMPLITUDE")]
    public float frequency = 0.5f;
	public float amplitude = 4f;
	public bool isRight=true;
	[Header("ROTATION")]
    public float degreesPerSecond = 0f;
	public float maxRotate=0.0f;
	public float minRotate=0.0f;
	public bool isRightRotate= true;

    // Position Storage Variables
    private Vector2 posOffset = new Vector2 ();
    private Vector2 tempPos = new Vector2 ();
 
    // Use this for initialization
    void Start () {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }
     
    // Update is called once per frame
    void Update () {
		
		//ROTATION
		float rotationSpeed= Time.deltaTime * degreesPerSecond;

		switch(isRigthRotation())
		{
			case true: 		
				transform.Rotate(new Vector3(0f,0f,-rotationSpeed), Space.World);
				break;
			case false:
				transform.Rotate(new Vector3(0f,0f,rotationSpeed), Space.World);
				break;	
		}

		//AMPLITUDE
        // Float up/down with a Sin()
        tempPos = posOffset;
		if(isRight)
		{
        	tempPos.x += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
		}
		else
		{
			
        	tempPos.x -= Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
		}
 
        transform.position = tempPos;
    }

	private bool isRigthRotation(){
		float currentrot=transform.rotation.eulerAngles.z;
		//Rota con un limite de rotación en Z determinado
		if(currentrot==maxRotate)
		{
			isRightRotate=false;
		}
		else if(currentrot==minRotate)
		{
			isRightRotate=true;
		}

		return isRightRotate;
	}

	
}
