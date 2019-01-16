using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
//------------------------------------------------------------
//						VARIABLES
//------------------------------------------------------------
	[Header("UI")]
	public Button playButton;
	public Text playText;
	public Text countDownText; 
	public float timeLeft;
//_____________________________________________________________________________
	public static bool isDead,isFinish;
	GameObject player;
	Scene currentScene;
//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------
	void Start () 
	{
		playText.text = "";
		isDead=false;
		isFinish=false;
		player= GameObject.FindGameObjectWithTag("Player");
		currentScene=SceneManager.GetActiveScene();//nombre de la escena actual
		
		playButton.gameObject.SetActive(false);
		// player.GetComponent<BallForwardController>().enabled=false;//el jugador no se mueve, esperando cuenta atras

	}

	void Update() 
	{
		if(isDead)
		{
			dead();
		}
		// if(isFinish)
		// {
		// 	finish();
		// }
		// cuentaAtras();
	}

//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void dead()
	{
		playText.text="PLAY!";
		playButton.gameObject.SetActive(true);
		player.SetActive(false);
		isDead=false;

	}

//finalización del level
	void finish()
	{
		
		playText.text="FINISH?";
		playButton.gameObject.SetActive(true);
		player.SetActive(false);
	}
	
	public void restartGame()
    {
		isDead=false;
        SceneManager.LoadScene(currentScene.name); //Carga de nuevo la escena principal
    }

//Cuenta atras al empezar la pantalla
	void cuentaAtras()
	{
		TimersGame.waitInit();
		timeLeft-= Time.deltaTime;

		if(timeLeft<=1)//cuenta acabada
		{
			StartCoroutine(waitToGo());
		}
		else
		{
			countDownText.text=Mathf.Round(timeLeft).ToString();

		}
	}
    IEnumerator waitToGo()
    {
        yield return new WaitForSeconds(0);
		countDownText.text= "GO!";
		player.GetComponent<BallForwardController>().enabled=true;//el jugador se mueve
		timeLeft=0;

    }
}
