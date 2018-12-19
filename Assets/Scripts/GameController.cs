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
	public void dead()
	{
		playText.text="PLAY";
		playButton.gameObject.SetActive(true);
		Destroy(player);

	}
	public void restartGame()
    {
		isDead=false;
        SceneManager.LoadScene("SampleScene"); //Carga de nuevo la escena principal
    }
}
