using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_for_every_passive_upgrade : MonoBehaviour
{
	public bool rockets1 = false;
	public bool mines = false;
	public bool turret = false;
	public bool alarm_system = false;
	public bool rockets2 = false;
	public GameObject objects_upgrade;
	public GameObject Generate_enemies;
	GameObject[] enemies;
	bool reloaded_completed = true;
	bool generated_mines = false;
	bool alarm_activated = false;

	GameObject[] al_enemies;
	GameObject enemy;
	float low_distance = Mathf.Infinity;
	float distance;
	
	void Update()
	{
		if (!Generate_enemies.GetComponent<Generate_enemies>().stop)
		{
			if (PlayerPrefs.GetInt("TURNED ON ROCKETS 1") == 1 && PlayerPrefs.GetInt("ROCKETS 1") == 1 && rockets1)
			{
				enemies = GameObject.FindGameObjectsWithTag("Enemy");
				if (enemies != null)
				{


					if (reloaded_completed)
					{
						GameObject part_upgrade = Instantiate(objects_upgrade);
						part_upgrade.SetActive(true);
						StartCoroutine(start_reloading(15f));
					}
				}
			}
		} else
		{
			StopAllCoroutines();
			reloaded_completed = true;
		}



		if (PlayerPrefs.GetInt("TURNED ON MINES") == 1 && PlayerPrefs.GetInt("MINES") == 1 && mines)
		{

			if (!Generate_enemies.GetComponent<Generate_enemies>().stop)
			{
				if (!generated_mines)
				{
					Debug.Log("GEN");
					generated_mines = true;
					GameObject obj = Instantiate(objects_upgrade);
					obj.SetActive(true);
				}
			}
			else
			{
				if (generated_mines)
				{
					generated_mines = false;
				}
			}
		}



		if (PlayerPrefs.GetInt("TURNED ON TURRETS") == 1 && PlayerPrefs.GetInt("TURRETS") == 1 && turret)
		{

			if (!Generate_enemies.GetComponent<Generate_enemies>().stop)
			{
				objects_upgrade.SetActive(true);
			}
			else
			{
				objects_upgrade.SetActive(false);
			}
		}



		if (PlayerPrefs.GetInt("TURNED ON ALARM SYSTEM") == 1 && PlayerPrefs.GetInt("ALARM SYSTEM") == 1 && alarm_system)
		{

			if (!Generate_enemies.GetComponent<Generate_enemies>().stop)
			{
				if (!alarm_activated)
				{
					al_enemies = GameObject.FindGameObjectsWithTag("Enemy");
					if (al_enemies.Length > 0)
					{
						for (int i = 0; i < al_enemies.Length; i++)
						{
							distance = Vector2.Distance(al_enemies[i].transform.position, transform.position);
							if (distance < low_distance)
							{
								enemy = al_enemies[i];
								low_distance = distance;
							}
						}
						if (low_distance <= 0.8f)
						{
							objects_upgrade.SetActive(true);
							alarm_activated = true;
						}

						low_distance = Mathf.Infinity;
					}

				}

			}
			else
			{
				alarm_activated = false;
			}
		}




		if (!Generate_enemies.GetComponent<Generate_enemies>().stop)
		{
			if (PlayerPrefs.GetInt("TURNED ON ROCKETS 2") == 1 && PlayerPrefs.GetInt("ROCKETS 2") == 1 && rockets2)
			{
				enemies = GameObject.FindGameObjectsWithTag("Enemy");
				if (enemies != null)
				{


					if (reloaded_completed)
					{
						GameObject part_upgrade = Instantiate(objects_upgrade);
						part_upgrade.SetActive(true);
						StartCoroutine(start_reloading(20f));
					}
				}
			}
		} else
		{
			StopAllCoroutines();
			reloaded_completed = true;
		}
		


	}
	IEnumerator start_reloading(float time_reloading)
	{
		reloaded_completed = false;
		yield return new WaitForSeconds(time_reloading);
		if (!Generate_enemies.GetComponent<Generate_enemies>().stop)
		{
			reloaded_completed = true;
		}
	}
}
