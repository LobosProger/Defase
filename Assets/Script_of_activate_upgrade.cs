using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Script_of_activate_upgrade : MonoBehaviour, IPointerDownHandler
{
	public GameObject box;
	public GameObject description;

	public bool emp1 = false;
	public bool shockwave = false;
	public bool nuke = false;
	public bool rockets1 = false;

	public bool emp2 = false;
	public bool mines = false;
	public bool turret = false;
	public bool gravity_bomb = false;

	public bool alarm_system = false;
	public bool upgraded_cross = false;
	public bool rockets2 = false;
	public bool inhibitor_time = false;

	public void OnPointerDown(PointerEventData eventData)
	{
		if (emp1)
		{
			if (PlayerPrefs.GetInt("EMP 1") == 1)
			{
				if (PlayerPrefs.GetInt("TURNED ON EMP 1") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON EMP 1", 1);
					PlayerPrefs.SetInt("TURNED ON SHOCKWAVE 1", 0);
					PlayerPrefs.SetInt("TURNED ON NUKE BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON EMP 2", 0);
					PlayerPrefs.SetInt("TURNED ON GRAVITY BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON INHIBITOR TIME", 0);
				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON EMP 1", 0);
				}
			}
		}

		if(shockwave)
		{
			if (PlayerPrefs.GetInt("SHOCKWAVE 1") == 1)
			{
				if (PlayerPrefs.GetInt("TURNED ON SHOCKWAVE 1") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON EMP 1", 0);
					PlayerPrefs.SetInt("TURNED ON SHOCKWAVE 1", 1);
					PlayerPrefs.SetInt("TURNED ON NUKE BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON EMP 2", 0);
					PlayerPrefs.SetInt("TURNED ON GRAVITY BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON INHIBITOR TIME", 0);
				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON SHOCKWAVE 1", 0);
				}
			}
		}

		if (nuke)
		{
			
			if (PlayerPrefs.GetInt("NUKE BOMB") == 1)
			{
				
				if (PlayerPrefs.GetInt("TURNED ON NUKE BOMB") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON EMP 1", 0);
					PlayerPrefs.SetInt("TURNED ON SHOCKWAVE 1", 0);
					PlayerPrefs.SetInt("TURNED ON NUKE BOMB", 1);
					PlayerPrefs.SetInt("TURNED ON EMP 2", 0);
					PlayerPrefs.SetInt("TURNED ON GRAVITY BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON INHIBITOR TIME", 0);
				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON NUKE BOMB", 0);
				}
			}
		}

		if (emp2)
		{
			if (PlayerPrefs.GetInt("EMP 2") == 1)
			{
				if (PlayerPrefs.GetInt("TURNED ON EMP 2") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON EMP 1", 0);
					PlayerPrefs.SetInt("TURNED ON SHOCKWAVE 1", 0);
					PlayerPrefs.SetInt("TURNED ON NUKE BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON EMP 2", 1);
					PlayerPrefs.SetInt("TURNED ON GRAVITY BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON INHIBITOR TIME", 0);
				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON EMP 2", 0);
				}
			}
		}

		if (gravity_bomb)
		{
			if (PlayerPrefs.GetInt("GRAVITY BOMB") == 1)
			{
				if (PlayerPrefs.GetInt("TURNED ON GRAVITY BOMB") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON EMP 1", 0);
					PlayerPrefs.SetInt("TURNED ON SHOCKWAVE 1", 0);
					PlayerPrefs.SetInt("TURNED ON NUKE BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON EMP 2", 0);
					PlayerPrefs.SetInt("TURNED ON GRAVITY BOMB", 1);
					PlayerPrefs.SetInt("TURNED ON INHIBITOR TIME", 0);
				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON GRAVITY BOMB", 0);
				}
			}
		}

		if (inhibitor_time)
		{
			if (PlayerPrefs.GetInt("INHIBITOR TIME") == 1)
			{
				if (PlayerPrefs.GetInt("TURNED ON INHIBITOR TIME") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON EMP 1", 0);
					PlayerPrefs.SetInt("TURNED ON SHOCKWAVE 1", 0);
					PlayerPrefs.SetInt("TURNED ON NUKE BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON EMP 2", 0);
					PlayerPrefs.SetInt("TURNED ON GRAVITY BOMB", 0);
					PlayerPrefs.SetInt("TURNED ON INHIBITOR TIME", 1);
				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON INHIBITOR TIME", 0);
				}
			}
		}

		if(rockets1)
		{
			if (PlayerPrefs.GetInt("ROCKETS 1") == 1)
			{
				if (PlayerPrefs.GetInt("TURNED ON ROCKETS 1") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON ROCKETS 1", 1);
					PlayerPrefs.SetInt("TURNED ON ALARM SYSTEM", 0);
					PlayerPrefs.SetInt("TURNED ON ROCKETS 2", 0);
					
				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON ROCKETS 1", 0);
				}
			}
		}

		if (alarm_system)
		{
			if (PlayerPrefs.GetInt("ALARM SYSTEM") == 1)
			{
				if (PlayerPrefs.GetInt("TURNED ON ALARM SYSTEM") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON ROCKETS 1", 0);
					PlayerPrefs.SetInt("TURNED ON ALARM SYSTEM", 1);
					PlayerPrefs.SetInt("TURNED ON ROCKETS 2", 0);

				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON ALARM SYSTEM", 0);
				}
			}
		}

		if(rockets2)
		{
			if (PlayerPrefs.GetInt("ROCKETS 2") == 1)
			{
				if (PlayerPrefs.GetInt("TURNED ON ROCKETS 2") == 0)
				{
					PlayerPrefs.SetInt("TURNED ON ROCKETS 1", 0);
					PlayerPrefs.SetInt("TURNED ON ALARM SYSTEM", 0);
					PlayerPrefs.SetInt("TURNED ON ROCKETS 2", 1);

				}
				else
				{
					PlayerPrefs.SetInt("TURNED ON ROCKETS 2", 0);
				}
			}
		}
	}

	void Update()
	{
		if (emp1)
		{
			if (PlayerPrefs.GetInt("EMP 1") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON EMP 1") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			} else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if(shockwave)
		{
			if (PlayerPrefs.GetInt("SHOCKWAVE 1") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON SHOCKWAVE 1") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if (nuke)
		{
			if (PlayerPrefs.GetInt("NUKE BOMB") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON NUKE BOMB") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if (emp2)
		{
			if (PlayerPrefs.GetInt("EMP 2") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON EMP 2") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if (gravity_bomb)
		{
			if (PlayerPrefs.GetInt("GRAVITY BOMB") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON GRAVITY BOMB") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if (inhibitor_time)
		{
			if (PlayerPrefs.GetInt("INHIBITOR TIME") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON INHIBITOR TIME") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if(rockets1)
		{
			if (PlayerPrefs.GetInt("ROCKETS 1") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON ROCKETS 1") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if(alarm_system)
		{
			if (PlayerPrefs.GetInt("ALARM SYSTEM") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON ALARM SYSTEM") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if (rockets2)
		{
			if (PlayerPrefs.GetInt("ROCKETS 2") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			if (PlayerPrefs.GetInt("TURNED ON ROCKETS 2") == 1)
			{
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
			else
			{
				gameObject.GetComponent<Image>().color = new Color(1f, 0, 0, 1f);
			}
		}

		if(upgraded_cross)
		{
			if (PlayerPrefs.GetInt("Upgraded cross") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
		}

		if (mines)
		{
			if (PlayerPrefs.GetInt("MINES") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
		}

		if (turret)
		{
			if (PlayerPrefs.GetInt("TURRETS") == 1)
			{
				description.SetActive(true);
				box.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
				gameObject.GetComponent<Image>().color = new Color(0, 1f, 0, 1f);
			}
		}
	}
}
	
