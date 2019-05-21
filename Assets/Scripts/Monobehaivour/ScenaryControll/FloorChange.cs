using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChange : MonoBehaviour 
{
	[Header("Pasos de Caminos")]
	public string plantaDown;
	public string plantaUP;

	GameObject player; 
	private  SpriteRenderer spriteRenderer;
	
	void Start()
	{
		player= GameObject.FindGameObjectWithTag("Player");
		spriteRenderer=player.GetComponent<SpriteRenderer>();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			//detectamos el layer del jugador para saber en que piso esta
			switch(player.layer)
			{
				//PlayerZone-4(piso superior)-> paso a piso inferior
				case 12:
					spriteRenderer.sortingLayerName=plantaDown;
					spriteRenderer.sortingOrder=2;
					player.layer=10;
					GameController.isDead=false;
					//cambiamos el layer del propio objeto
					this.gameObject.layer= 10;
				break;
				
				//PlayerZone-2 (piso inferior)-> cambio a piso superior
				case 10:
					spriteRenderer.sortingLayerName=plantaUP;
					spriteRenderer.sortingOrder=4;
					player.layer=12;
					GameController.isDead=false;
				break;

			}
		}
	}
}
