using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom_mine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			other.GetComponent<Enemy_script>().health -= 1f;
		}
	}
}
