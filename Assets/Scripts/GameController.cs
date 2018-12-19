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
	[Header("OBJECTS")]
	public GameObject player;

	public static bool isDead;
	//These are your Scene names. Make sure to set them in the Inspector window
    public string m_MyFirstScene, m_MySecondScene;
    Scene m_Scene;
//------------------------------------------------------------
//						MAIN METHODS
//------------------------------------------------------------
	void Start () 
	{
		playText.text = "";
		isDead=false;
		playButton.gameObject.SetActive(false);
	}

	void Update() 
	{
		//Return the current Active Scene in order to get the current Scene's name
        m_Scene = SceneManager.GetActiveScene();
		

		if(isDead)
		{
			dead();
		}
	}

//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	public void dead()
	{
		playText.text="PLAY";
		playButton.gameObject.SetActive(true);
		Destroy(player);

	}
	public void restartGame()
    {
		isDead=false;
        SceneManager.LoadScene(m_Scene.name); //Carga de nuevo la escena principal
		Debug.Log("Escena:"+ m_Scene.name);
    }
}
