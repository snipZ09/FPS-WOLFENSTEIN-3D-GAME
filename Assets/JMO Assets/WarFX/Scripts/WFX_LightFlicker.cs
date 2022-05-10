using UnityEngine;
using System.Collections;

/**
 *	Rapidly sets a light on/off.
 *	
 *	(c) 2015, Jean Moreno
**/

[RequireComponent(typeof(Light))]
public class WFX_LightFlicker : MonoBehaviour
{
	public float time = 0.05f;
	
	private float timer;
	
	void Update ()
	{
		if (M4A1Fire.instance.isFiring)
		{
			GetComponent<Light>().enabled = true;
		}
		else
		{
			GetComponent<Light>().enabled = false;
		}
	}
}
