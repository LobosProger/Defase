using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_turret : MonoBehaviour
{
	
	bool reload_comp = true;
	bool shoot = false;
	float low_distance = Mathf.Infinity;
	float distance;
	GameObject enemy;
	GameObject[] enemies;
	public GameObject[] shots;
	public GameObject[] bullets;
	public GameObject[] spawns;
	public AudioSource shot_sound;
	void OnEnable()
	{
		reload_comp = true;
	}
	void FixedUpdate()
    {
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length > 0)
		{
			for (int i = 0; i < enemies.Length; i++)
			{
				distance = Vector2.Distance(enemies[i].transform.position, transform.position);
				if (distance < low_distance)
				{
					enemy = enemies[i];
					low_distance = distance;
				}
			}
			low_distance = Mathf.Infinity;
			Vector3 directionToTarget = (enemy.transform.position - transform.position).normalized;
			directionToTarget.z = 0;
			transform.up = directionToTarget;
			if (reload_comp && enemy.GetComponent<PolygonCollider2D>().enabled && Vector2.Distance(enemy.transform.position, transform.position) <= 10f)
			{
				StartCoroutine(Shoot());
			}
		}
		
	}
	IEnumerator Shoot()
	{
		if (reload_comp)
		{
			StartCoroutine(Fire());
			Debug.Log("FIRE");
			reload_comp = false;
			yield return new WaitForSeconds(15f);
			reload_comp = true;
		}
	}
	IEnumerator Fire()
	{
		foreach (GameObject fires in shots)
		{
			fires.SetActive(true);
		}
		int sp = 0;
		foreach (GameObject bul in bullets)
		{
			GameObject b = Instantiate(bul);
			b.transform.rotation = transform.rotation;
			b.transform.position = spawns[sp].transform.position;
			b.SetActive(true);
			sp++;
		}
		sp = 0;
		shot_sound.Play();
		yield return new WaitForSeconds(0.3f);
		foreach (GameObject fires in shots)
		{
			fires.SetActive(false);
		}
	}
	
}
