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
	[Header("COSETAS")]
	public string nameScene;
	//These are your Scene names. Make sure to set them in the Inspector window
    public string m_MyFirstScene, m_MySecondScene;

	public static bool isDead;

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
		if(isDead)
		{
			dead();
		}
	}

//------------------------------------------------------------
//						METHODS
//------------------------------------------------------------
	void dead()
	{
		playText.text="PLAY";
		playButton.gameObject.SetActive(true);
		Destroy(player);

	}
	public void restartGame()
    {
		isDead=false;
        SceneManager.LoadScene(nameScene); //Carga de nuevo la escena principal
    }
}
