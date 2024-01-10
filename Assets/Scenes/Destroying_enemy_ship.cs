using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroying_enemy_ship : MonoBehaviour
{
	public GameObject ship;
	public AudioSource boom_sound;
	bool destroy = false;
	void Update()
	{
		if(destroy)
		{
			if(!boom_sound.isPlaying)
			{
				ship.GetComponent<Enemy_script>().destroy_of_ship();
			}
		}
	}
	public void Destroy_ship()
	{
		destroy = true;
		
	}
    
}
