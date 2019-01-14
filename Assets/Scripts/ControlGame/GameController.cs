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

	[Header("OBJECTS")]
	public GameObject player;

	[Header("ESCENAS")]
	public string nameScene;
	//These are your Scene names. Make sure to set them in the Inspector window
    public string m_MyFirstScene, m_MySecondScene;

	public static bool isDead,isFinish;

    Scene m_Scene;
//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------
	void Start () 
	{
		playText.text = "";
		isDead=false;
		isFinish=false;
		playButton.gameObject.SetActive(false);
		player.GetComponent<BallForwardController>().enabled=false;//el jugador no se mueve

	}

	void Update() 
	{
		if(isDead)
		{
			dead();
		}
		if(isFinish)
		{
			finish();
		}
		cuentaAtras();
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

	void finish()
	{
		
		playText.text="FINISH?";
		playButton.gameObject.SetActive(true);
		player.SetActive(false);
	}
	
	public void restartGame()
    {
		isDead=false;
        SceneManager.LoadScene(nameScene); //Carga de nuevo la escena principal
    }

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
