using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//static de esta forma tenemos acceso rápido a los métodos en las otras clases
public static class InputManager
{
	//-------------------------------------------------
	//					MOVIMIENTO
	//-------------------------------------------------
	public static float MainHorizontal()
	{
		return Input.GetAxisRaw ("Horizontal");
	}
	public static float MainVertical()
	{
		return Input.GetAxisRaw ("Vertical");
	}

	//-------------------------------------------------
	//					BOTONES
	//-------------------------------------------------

}
