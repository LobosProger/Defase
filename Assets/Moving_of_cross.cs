using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Moving_of_cross : MonoBehaviour
{
	public Rigidbody2D rb;
	public Animator anim_cross;
	public AudioSource shoot;
	public GameObject shots;
	public Slider sl;
	public float damage = 1f;
	public float sensiv_for_slider;
	void Start()
	{
		
		PlayerPrefs.GetFloat("Sensivity", 16f);
		if(PlayerPrefs.GetFloat("Sensivity") == 0)
		{
			PlayerPrefs.SetFloat("Sensivity", 16f);
		}
		sl.value = PlayerPrefs.GetFloat("Sensivity");
		sensiv_for_slider = PlayerPrefs.GetFloat("Sensivity");
	}
	void FixedUpdate()
    {

			PlayerPrefs.SetFloat("Sensivity", sensiv_for_slider);
			Vector3 acc = Input.acceleration;
			rb.velocity = new Vector3(acc.x, acc.y, 0) * sensiv_for_slider;
			rb.position = new Vector3(Mathf.Clamp(rb.position.x, -8.883f, 8.876f), Mathf.Clamp(rb.position.y, -4.992f, 4.987f), 0);
			
		
	}
	public void Shoot()
	{
		
			if (Time.timeScale != 0f)
			{
				shots.GetComponent<To_fix_current_score>().current_score++;
				anim_cross.Play("Animation_of_shoot");
				shoot.Play();
			}
		
	}
	public void Change_sen()
	{
		sensiv_for_slider = sl.value;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			
			
			other.GetComponent<Enemy_script>().health = other.GetComponent<Enemy_script>().health - damage;
			
		}
	}
	
}
