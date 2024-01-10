using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_rockets : MonoBehaviour
{
	public float damage = 1f;
	public GameObject parent_object;
	public GameObject boom;
	public GameObject fire_from_rocket;
	public AudioSource sound_flying_rocket;
	public float speed = 10f;
	public GameObject place_of_spawn;
	GameObject Target;
	public GameObject[] array_enemies;
	public float distance = Mathf.Infinity;
	public int index;
	float low_distance = Mathf.Infinity;
	int i;
	bool destroyed = false;
	void Start()
	{
			transform.position = place_of_spawn.transform.position;
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		if (!destroyed)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			if (enemies.Length > 0)
			{
				for (int i = 0; i < enemies.Length; i++)
				{
					distance = Vector2.Distance(enemies[i].transform.position, place_of_spawn.transform.position);
					if (distance < low_distance)
					{
						Target = enemies[i];
						low_distance = distance;
					}
				}
				low_distance = Mathf.Infinity;
				Vector3 directionToTarget = (Target.transform.position - transform.position).normalized;
				directionToTarget.z = 0;
				transform.up = directionToTarget;
			}
		}
		if (!destroyed && Target != null)
		{

			Vector3 directionToTarget = (Target.transform.position - transform.position).normalized;
			directionToTarget.z = 0;
			transform.up = directionToTarget;
			transform.position += (Target.transform.position - transform.position).normalized * Time.deltaTime * speed / 4f;

		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			if (!destroyed)
			{
				other.GetComponent<Enemy_script>().health -= damage;
				StartCoroutine(Destroy_rocket());
				destroyed = true;
			}
		}
	}

	public IEnumerator Destroy_rocket()
	{

		sound_flying_rocket.Stop();
		boom.SetActive(true);
		gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
		Destroy(fire_from_rocket);
		yield return new WaitForSeconds(4f);
		Destroy(parent_object);
	}
}

