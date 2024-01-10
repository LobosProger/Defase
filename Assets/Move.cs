using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
	public bool up = false;
	public bool down = false;
	public GameObject pl;
	public GameObject nen;
	void Start()
	{
		if (pl == null)
		{
			pl = GameObject.FindGameObjectWithTag("Player");
			return;
		}
		Debug.Log("Find");
	}
	
	
}
