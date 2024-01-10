using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_anim_dev : MonoBehaviour
{
    
    void Start()
    {
		StartCoroutine(Turn_off_dev());
    }

	IEnumerator Turn_off_dev()
	{
		yield return new WaitForSeconds(4f);
		gameObject.SetActive(false);
	}
}
