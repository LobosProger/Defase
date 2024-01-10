using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roulette_script : MonoBehaviour
{
	public bool ch = false;
	int i = 0;

	public int chance_of_drop_big_money = 10;
	public int chance_of_drop_upgrade = 15;

	public int chance_of_drop_epic_upgrade = 5;
	public int chance_of_drop_relict_upgrade = 3;

	public bool activate = false;

	bool reward = false;
	bool reward_money = false;
	bool reward_simple = false;
	bool reward_epic = false;
	bool reward_relict = false;

	public Animator spining_arrow;
	public GameObject rew;

	public GameObject[] upgrades;
	public Text text_amount_of_rewarded_coins;
	void Start()
	{
		
		spining_arrow = gameObject.GetComponentInChildren<Animator>();
	}


	void Update()
	{
		if(!ch)
		{
			i = 0;
		}
		if (activate || ch)
		{
			i++;
			int random_number = Random.Range(1, 101);
			if (random_number >= 1 && random_number <= chance_of_drop_upgrade)
			{
				

				if(random_number >= 1 && random_number <= chance_of_drop_relict_upgrade) //РЕЛИКТ
				{
					transform.rotation = Quaternion.Euler(0, 0, Random.Range(270.9f, 273f));
					spining_arrow.Play("Animation of moving arrow");
					Debug.Log("RELICT UPGRADE");
					Debug.Log(i);
					reward = true;
					ch = false;
					reward_relict = true;
				} else if(random_number >= 1 && random_number <= chance_of_drop_epic_upgrade) //ЭПИЧЕСКИЙ
				{
					transform.rotation = Quaternion.Euler(0, 0, Random.Range(274.93f, 279.48f));
					spining_arrow.Play("Animation of moving arrow");
					Debug.Log("EPIC UPGRADE");
					reward = true;
					reward_epic = true;
				} else //ОБЫЧНЫЙ
				{
					transform.rotation = Quaternion.Euler(0, 0, Random.Range(282.65f, 303.8f));
					spining_arrow.Play("Animation of moving arrow");
					Debug.Log("SIMPLE UPGRADE");
					reward = true;
					reward_simple = true;
				}
				
			}
			else //ДЕНЬГИ
			{
				random_number = Random.Range(1, 101);
				if (random_number >= 1 && random_number <= chance_of_drop_big_money) //МОНЕТКИ
				{
					transform.rotation = Quaternion.Euler(0, 0, Random.Range(-51.77f, -19.57f));
					spining_arrow.Play("Animation of moving arrow");
					Debug.Log("MONEY");
					reward = true;
					reward_money = true;
				} else
				{
					transform.rotation = Quaternion.Euler(0, 0, Random.Range(74.4f, 268.0f));
					spining_arrow.Play("Animation of moving arrow");
					Debug.Log("LOSE"); 
				}
			}
			activate = false;
		} else if(this.spining_arrow.GetCurrentAnimatorStateInfo(0).IsName("Normal State"))
		{
			transform.rotation = new Quaternion(0, 0, 0, 0);
			if (reward)
			{
				if(reward_money)
				{
					int random_number_for_simple_coins = Random.Range(200, 300);
					PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + random_number_for_simple_coins);
					upgrades[4].SetActive(true);
					text_amount_of_rewarded_coins.text = random_number_for_simple_coins.ToString();
					reward = false;
					reward_money = false;
				}
				if (reward_simple)
				{
					int random_upgrade = Random.Range(1, 5);
					if (
						PlayerPrefs.GetInt("EMP 1") == 0 ||
						PlayerPrefs.GetInt("SHOCKWAVE 1") == 0 ||
						PlayerPrefs.GetInt("NUKE BOMB") == 0 ||
						PlayerPrefs.GetInt("ROCKETS 1") == 0
						)
					{
						
						switch (random_upgrade)
						{
							case 1:
								if (PlayerPrefs.GetInt("EMP 1") == 0)
								{
									upgrades[0].SetActive(true);
									PlayerPrefs.SetInt("EMP 1", 1);
									Debug.Log("emp");
									reward = false;
									reward_simple = false;
								}
								break;
							case 2:
								if (PlayerPrefs.GetInt("SHOCKWAVE 1") == 0)
								{
									upgrades[1].SetActive(true);
									PlayerPrefs.SetInt("SHOCKWAVE 1", 1);
									Debug.Log("shockwave");
									reward = false;
									reward_simple = false;
								}
								break;
							case 3:
								if (PlayerPrefs.GetInt("NUKE BOMB") == 0)
								{
									upgrades[2].SetActive(true);
									PlayerPrefs.SetInt("NUKE BOMB", 1);
									Debug.Log("nuke");
									reward = false;
									reward_simple = false;
								}
								break;
							case 4:
								if (PlayerPrefs.GetInt("ROCKETS 1") == 0)
								{
									upgrades[3].SetActive(true);
									PlayerPrefs.SetInt("ROCKETS 1", 1);
									Debug.Log("rockets");
									reward = false;
									reward_simple = false;
								}
								break;
						}
					}
					else
					{
						Debug.Log("NO");
						upgrades[4].SetActive(true); //МОНЕТЫ, ЕСЛИ ВСЕ УЛУЧШЕНИЯ ПОЛУЧЕНЫ
						int random_number_for_simple_coins = Random.Range(100, 150);
						PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + random_number_for_simple_coins);
						text_amount_of_rewarded_coins.text = random_number_for_simple_coins.ToString();
						reward = false;
						reward_simple = false;
					}
				}
				if (reward_epic)
				{
					int random_upgrade = Random.Range(1, 5);
					if (
						PlayerPrefs.GetInt("EMP 2") == 0 ||
						PlayerPrefs.GetInt("MINES") == 0 ||
						PlayerPrefs.GetInt("TURRETS") == 0 ||
						PlayerPrefs.GetInt("GRAVITY BOMB") == 0
						)
					{

						switch (random_upgrade)
						{
							case 1:
								if (PlayerPrefs.GetInt("EMP 2") == 0)
								{
									upgrades[5].SetActive(true);
									PlayerPrefs.SetInt("EMP 2", 1);
									Debug.Log("emp 2");
									reward = false;
									reward_epic = false;
								}
								break;
							case 2:
								if (PlayerPrefs.GetInt("MINES") == 0)
								{
									upgrades[6].SetActive(true);
									PlayerPrefs.SetInt("MINES", 1);
									PlayerPrefs.SetInt("TURNED ON MINES", 1);
									Debug.Log("mines");
									reward = false;
									reward_epic = false;
								}
								break;
							case 3:
								if (PlayerPrefs.GetInt("TURRETS") == 0)
								{
									upgrades[7].SetActive(true);
									PlayerPrefs.SetInt("TURRETS", 1);
									PlayerPrefs.SetInt("TURNED ON TURRETS", 1);
									Debug.Log("turret");
									reward = false;
									reward_epic = false;
								}
								break;
							case 4:
								if (PlayerPrefs.GetInt("GRAVITY BOMB") == 0)
								{
									upgrades[8].SetActive(true);
									PlayerPrefs.SetInt("GRAVITY BOMB", 1);
									Debug.Log("gravity bomb");
									reward = false;
									reward_epic = false;
								}
								break;
						}
					}
					else
					{
						Debug.Log("NO");
						upgrades[4].SetActive(true); //МОНЕТЫ, ЕСЛИ ВСЕ УЛУЧШЕНИЯ ПОЛУЧЕНЫ
						int random_number_for_simple_coins = Random.Range(150, 200);
						PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + random_number_for_simple_coins);
						text_amount_of_rewarded_coins.text = random_number_for_simple_coins.ToString();
						reward = false;
						reward_epic = false;
					}
				}
				if (reward_relict)
				{
					int random_upgrade = Random.Range(1, 5);
					if (
						PlayerPrefs.GetInt("ALARM SYSTEM") == 0 ||
						PlayerPrefs.GetInt("Upgraded cross") == 0 ||
						PlayerPrefs.GetInt("ROCKETS 2") == 0 ||
						PlayerPrefs.GetInt("INHIBITOR TIME") == 0 
						)
					{

						switch (random_upgrade)
						{
							case 1:
								if (PlayerPrefs.GetInt("ALARM SYSTEM") == 0)
								{
									upgrades[9].SetActive(true);
									PlayerPrefs.SetInt("ALARM SYSTEM", 1);
									Debug.Log("alarm system");
									reward = false;
									reward_relict = false;
								}
								break;
							case 2:
								if (PlayerPrefs.GetInt("Upgraded cross") == 0)
								{
									upgrades[10].SetActive(true);
									PlayerPrefs.SetInt("Upgraded cross", 1);
									Debug.Log("cross");
									reward = false;
									reward_relict = false;
								}
								break;
							case 3:
								if (PlayerPrefs.GetInt("ROCKETS 2") == 0)
								{
									upgrades[11].SetActive(true);
									PlayerPrefs.SetInt("ROCKETS 2", 1);
									Debug.Log("rockets 2");
									reward = false;
									reward_relict = false;
								}
								break;
							case 4:
								if (PlayerPrefs.GetInt("INHIBITOR TIME") == 0)
								{
									upgrades[12].SetActive(true);
									PlayerPrefs.SetInt("INHIBITOR TIME", 1);
									Debug.Log("inhibitor time");
									reward = false;
									reward_relict = false;
								}
								break;
						}
					}
					else
					{
						Debug.Log("NO");
						upgrades[4].SetActive(true); //МОНЕТЫ, ЕСЛИ ВСЕ УЛУЧШЕНИЯ ПОЛУЧЕНЫ
						int random_number_for_simple_coins = Random.Range(200, 300);
						PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + random_number_for_simple_coins);
						text_amount_of_rewarded_coins.text = random_number_for_simple_coins.ToString();
						reward = false;
						reward_relict = false;
					}
				}
				rew.SetActive(true);
			}
		}
		
		
	}
}

