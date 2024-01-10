using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy_script : MonoBehaviour
{
	bool big_enemy = false;
	float distance_to_taget;
	public GameObject Target;
	public Rigidbody2D rb;
	public float speed;
	public GameObject[] to_change_colors;
	public float health = 1f;
	public GameObject boom;
	public GameObject gen;
	int health_for_score;
	public GameObject score;
	public GameObject scor_for_pause;
	public GameObject kills;
	bool score_got = false;
	public bool first_ship = false;
	public int transformed_health;
	public bool emp_effect = false;
	void Start()
	{
		if(health == 0.5f)
		{
			health = 1f;
		}
		transformed_health = (int)Mathf.Round(health);
		switch (transformed_health)
		{
			case 1:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);

				}
				break;
			case 2:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);

				}
				break;
			case 3:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);

				}
				break;
			case 4:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);

				}
				break;

		}
		health_for_score = (int)health;
	}
	// Update is called once per frame
	void Update()
	{
		if (health == 0.5f || health == 1.5f)
		{
			health = 1f;
		}
		transformed_health = (int)Mathf.Round(health);
		switch (transformed_health)


		{
			case 0
:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);

				}
				break;
			case 1:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);

				}
				break;
			case 2:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(1, 1, 0, 1);

				}
				break;
			case 3:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);

				}
				break;
			case 4:
				foreach (GameObject every_element in to_change_colors)
				{
					every_element.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 1);

				}
				break;

		}
		if(health == 4f)
		{
			big_enemy = true;
		}
		if(health > 0)
		{
			if (!emp_effect)
			{
				Vector3 directionToTarget = (Target.transform.position - rb.transform.position).normalized;
				directionToTarget.z = 0;
				rb.transform.up = directionToTarget;
				Vector3 changed_target = Target.transform.position;

				distance_to_taget = Vector2.Distance(transform.position, Target.transform.position);
				if (distance_to_taget < 0.55f)
				{
					gen.GetComponent<Generate_enemies>().stop = true;
				}
				rb.transform.position += (Target.transform.position - rb.transform.position).normalized * Time.deltaTime * speed / 4f;
			} 
		} else
		{
			foreach (GameObject every_element in to_change_colors)
			{
				every_element.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
				PolygonCollider2D pol = gameObject.GetComponent<PolygonCollider2D>();
				pol.enabled = false;
			}
			if(!score_got)
			{
				if (!gen.GetComponent<Generate_enemies>().stop)
				{
					score.GetComponent<To_fix_current_score>().current_score += health_for_score;
					scor_for_pause.GetComponent<To_fix_current_score>().current_score += health_for_score;
					if(big_enemy)
					{
						PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 5);
					} else
					{
						PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 4);
					}
					
					if (PlayerPrefs.GetInt("Score", 0) < score.GetComponent<To_fix_current_score>().current_score)
					{
						PlayerPrefs.SetInt("Score", score.GetComponent<To_fix_current_score>().current_score);
					}
					kills.GetComponent<To_fix_current_score>().current_score++;
				}
				
				score_got = true;
			}
			boom.SetActive(true);
		}
	}
	public void destroy_of_ship()
	{
		
		Destroy(gameObject);
	}

	public float Map(float from, float to, float from2, float to2, float value) //ПРЕОБРАЗОВАНИЕ ОДНОГО ДИПАПОЗОНА ЗНАЧЕНИЯ В ДРУГОЙ
	{
		if (value <= from2)
		{
			return from;
		}
		else if (value >= to2)
		{
			return to;
		}
		else
		{
			return (to - from) * ((value - from2) / (to2 - from2)) + from;
		}
	}

	public IEnumerator turnOff_emp(float time_of_deactivating)
	{
		yield return new WaitForSeconds(time_of_deactivating);
		emp_effect = false;
	}
}
