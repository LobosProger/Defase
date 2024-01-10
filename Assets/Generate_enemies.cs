using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class Generate_enemies : MonoBehaviour
{
	bool boom_in_start = false;
	bool scored_for_gameover = false;
	public bool stop = false;
	
	float start_speed = 1f;
	float increase_speed_during_playing = 0.07f;
	public int random_max_enemies = 5;
	int random_min_enemies = 3;
	float random_time_max = 7.5f;
	float random_time_min = 5.5f;
	float real_time;
	float random_enemies;
	float random_time;
	public GameObject[] enemies;

	float start_speed_reserve;
	float increase_speed_during_playing_reserve;
	int random_max_enemies_reserve;
	int random_min_enemies_reserve;
	float random_time_max_reserve;
	float random_time_min_reserve;
	public int current_record_for_increase_enemy;

	public GameObject scor;
	public GameObject[] boards;
	public GameObject[] score_from_other;
	public GameObject[] score_from_gameover;

	public GameObject boom_station;
	public GameObject[] objects;
	public GameObject for_upgrades;

	public GameObject[] animate_in_start;
	public bool button_pause_pressed = false;

	int loses;
	void Start()
	{
		
		random_max_enemies++;
		random_time_max++;

		start_speed_reserve = start_speed;
		increase_speed_during_playing_reserve = increase_speed_during_playing;
		random_max_enemies_reserve = random_max_enemies;
		random_min_enemies_reserve = random_min_enemies;
		random_time_max_reserve = random_time_max;
		random_time_min_reserve = random_time_min;
		
	}
    void Update()
    {
		if (!stop)
		{
			if (score_from_other[0].GetComponent<To_fix_current_score>().current_score - current_record_for_increase_enemy >= 125)
			{
				random_max_enemies+=2;
				current_record_for_increase_enemy += 125;

			}
			foreach (GameObject every_object in objects)
			{
				every_object.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
			}
			scored_for_gameover = false;
			if (Time.fixedTime - real_time > random_time)
			{
				real_time = Time.fixedTime;
				random_enemies = Random.Range(random_min_enemies, random_max_enemies);
				random_time = Random.Range(random_time_min, random_time_max);
				real_time = Time.fixedTime;
				for (int i = 0; i < random_enemies; i++)
				{
					GameObject enemy = Instantiate(enemies[Random.Range(0, 3)]);

					int x = 0;
					int y = 0;
					while (x == 0 && y == 0 || x == 1 && y == 1)
					{
						x = Random.Range(0, 2);
						y = Random.Range(0, 2);
					}
					if (x == 1 && y == 0)
					{
						float X_position = Random.Range(-9.48f, 9.53f);
						enemy.transform.position = new Vector3(X_position, 5.49f, 0);
					}
					if (y == 1 && x == 0)
					{
						float Y_position = Random.Range(5.49f, -5.54f);
						x = Random.Range(0, 2);
						if (x == 0)
						{
							enemy.transform.position = new Vector3(-9.48f, Y_position, 0);
						}
						if (x == 1)
						{
							enemy.transform.position = new Vector3(9.53f, Y_position, 0);
						}
					}
					
					if (score_from_other[0].GetComponent<To_fix_current_score>().current_score >= 100)
					{
						enemy.GetComponent<Enemy_script>().health = Random.Range(1, 5);
					} else
					{
						enemy.GetComponent<Enemy_script>().health = Random.Range(1, 4);
					}
					
					enemy.GetComponent<Enemy_script>().speed = start_speed;
					enemy.SetActive(true);
				}
				start_speed += increase_speed_during_playing;
			}
		} else
		{

			if (boom_in_start)
			{
				GameObject[] rockets = GameObject.FindGameObjectsWithTag("Rockets");
				foreach(GameObject every_rocket in rockets)
				{
					StartCoroutine(every_rocket.GetComponent<For_rockets>().Destroy_rocket());
				}
				GameObject[] mines = GameObject.FindGameObjectsWithTag("Mines");
				foreach (GameObject every_mine in mines)
				{
					Destroy(every_mine);
				}
				Time.timeScale = 1f;
				for_upgrades.GetComponent<Script_of_every_board>().reload_completed = true;
				if (!scored_for_gameover)
				{
					foreach(GameObject every_animation in animate_in_start)
					{
						every_animation.SetActive(false);
					}
					boom_station.GetComponent<Animator>().Play("Animation_of_boom_station");
					
					foreach(GameObject every_object in objects)
					{
					every_object.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0);
					}
					foreach (GameObject every_board in boards)
					{
						if (every_board != null)
						{
							every_board.SetActive(false);
						}
					}
					for (int i = 0; i < score_from_other.Length; i++)
					{
						score_from_gameover[i].GetComponent<Score_in_gameover>().current_score_gameover = score_from_other[i].GetComponent<To_fix_current_score>().current_score;
						//Debug.Log(score_from_gameover[i].GetComponent<To_fix_current_score>().current_score);
					}
					scored_for_gameover = true;
					if (button_pause_pressed)
					{
						button_pause_pressed = false;
						
					} else
					{
						StartCoroutine(Activate_board_gameover());
					}
					StartCoroutine(Check());
					scor.GetComponent<To_fix_current_score>().current_score = 0;
					GameObject[] enemies_for_destroy = GameObject.FindGameObjectsWithTag("Enemy");
					foreach (GameObject every_enemy in enemies_for_destroy)
					{
						every_enemy.GetComponent<Enemy_script>().health = 0;
					}
					for (int i = 0; i < score_from_other.Length; i++)
					{
						score_from_other[i].GetComponent<To_fix_current_score>().current_score = 0;
					}
					start_speed = start_speed_reserve;
					increase_speed_during_playing = increase_speed_during_playing_reserve;
					random_max_enemies = random_max_enemies_reserve;
					random_min_enemies = random_min_enemies_reserve;
					random_time_max = random_time_max_reserve;
					random_time_min = random_time_min_reserve;
					current_record_for_increase_enemy = 0;
					
					
				}



			} else
			{
				boom_in_start = true;
				scored_for_gameover = true;
			}
		}
	}


	IEnumerator Activate_board_gameover()
	{
		yield return new WaitForSeconds(1.4f);
		boards[3].SetActive(true);
		StartCoroutine(Check());
	}

	
	IEnumerator Check()
	{
		yield return new WaitForSeconds(2.5f);
		if
		(
		boards[0].active == false &&
		boards[1].active == false &&
		boards[2].active == false &&
		boards[3].active == false
		)
		{
		boards[3].SetActive(true);
		}
	}

}
