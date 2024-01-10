using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Advertisements;
public class Script_of_every_board : MonoBehaviour, IPointerDownHandler
{
	public bool Button_pause = false;
	public bool Button_continue = false;
	public bool Button_restart = false;
	public bool Button_menu = false;
	public bool Button_share = false;
	public bool Button_agree = false;
	public bool Button_language = false;
	public bool Button_casino = false;
	public bool Button_spin = false;
	public bool Button_to_switch_menues = false;
	public bool Button_get_money = false;
	public bool Button_back_from_casino = false;
	public bool Button_reward = false;
	public bool Button_activate_upgrade = false;

	bool russian = false;
	public bool reload_completed = true;

	public GameObject for_share;
	public GameObject tut_share;
	public GameObject[] parts_to_turn_off_in_start;
	public GameObject board_to_turn_on;
	public GameObject generate_enemies_for_restart;
	public GameObject[] for_agree;
	public GameObject start_arrow;
	public GameObject money_ani;
	public GameObject[] upgrades;
	public GameObject[] animations_of_upgrades;
	Animator anim;
	Animator money_animator;
	void Start()
	{
		if(Button_activate_upgrade)
		{
			
			foreach (GameObject every_upgrade in upgrades)
			{
				every_upgrade.SetActive(false);
			}
		}
		if(Button_restart)
		{
			
			PlayerPrefs.GetInt("EMP 1", 0); //ОБЫЧНЫЕ УЛУЧШЕНИЯ
			PlayerPrefs.GetInt("SHOCKWAVE 1", 0);
			PlayerPrefs.GetInt("NUKE BOMB", 0);
			PlayerPrefs.GetInt("ROCKETS 1", 0);

			PlayerPrefs.GetInt("EMP 2", 0); //ЭПИЧЕСКИЕ УЛУЧШЕНИЯ
			PlayerPrefs.GetInt("MINES", 0);
			PlayerPrefs.GetInt("TURRETS", 0);
			PlayerPrefs.GetInt("GRAVITY BOMB", 0);

			PlayerPrefs.GetInt("ALARM SYSTEM", 0); //РЕЛИКТОВЫЕ УЛУЧШЕНИЯ
			PlayerPrefs.GetInt("Upgraded cross", 0);
			PlayerPrefs.GetInt("ROCKETS 2", 0);
			PlayerPrefs.GetInt("INHIBITOR TIME", 0);

			//ВКЛЮЧИЛ ЛИ ПОЛЬЗОВАТЕЛЬ ИХ

			PlayerPrefs.GetInt("TURNED ON EMP 1", 0); //ОБЫЧНЫЕ 
			PlayerPrefs.GetInt("TURNED ON SHOCKWAVE 1", 0);
			PlayerPrefs.GetInt("TURNED ON NUKE BOMB", 0);
			PlayerPrefs.GetInt("TURNED ON ROCKETS 1", 0);

			PlayerPrefs.GetInt("TURNED ON EMP 2", 0); //ЭПИЧЕСКИЕ 
			PlayerPrefs.GetInt("TURNED ON MINES", 0);
			PlayerPrefs.GetInt("TURNED ON TURRETS", 0);
			PlayerPrefs.GetInt("TURNED ON GRAVITY BOMB", 0);

			PlayerPrefs.GetInt("TURNED ON ALARM SYSTEM", 0); //РЕЛИКТОВЫЕ 
			PlayerPrefs.GetInt("TURNED ON ROCKETS 2", 0);
			PlayerPrefs.GetInt("TURNED ON INHIBITOR TIME", 0);
		}
		if (Button_get_money)
		{
			if (Advertisement.isSupported)
			{
				Advertisement.Initialize("3502779", false);
				Debug.Log("Complete!");
			}
			else
			{
				Debug.Log("Not supported");
			}
		}
		if (Button_language)
		{
			PlayerPrefs.GetInt("Russian", 0);
			if(PlayerPrefs.GetInt("Russian") == 0)
			{
				russian = false;
			}
			if (PlayerPrefs.GetInt("Russian") == 1)
			{
				russian = true;
			}
		}
		if(Button_agree)
		{
			PlayerPrefs.GetInt("Agree", 0);
			if (PlayerPrefs.GetInt("Agree") == 1)
			{
				foreach (GameObject every_agree in for_agree)
				{
					Destroy(every_agree);
				}
			}
		}
		if(Button_spin)
		{
			anim = start_arrow.GetComponentInChildren<Animator>();
			money_animator = money_ani.GetComponentInChildren<Animator>();
		}
		if (Button_back_from_casino)
		{
			anim = start_arrow.GetComponentInChildren<Animator>();
			money_animator = money_ani.GetComponentInChildren<Animator>();
		}
	}

	void OnEnable()
	{
		if (Button_activate_upgrade)
		{
			if (PlayerPrefs.GetInt("EMP 1") == 1 && PlayerPrefs.GetInt("TURNED ON EMP 1") == 1 && !reload_completed)
			{

				StartCoroutine(reload(20f));

			}
			if (PlayerPrefs.GetInt("SHOCKWAVE 1") == 1 && PlayerPrefs.GetInt("TURNED ON SHOCKWAVE 1") == 1 && !reload_completed)
			{

				StartCoroutine(reload(30f));

			}
			if (PlayerPrefs.GetInt("NUKE BOMB") == 1 && PlayerPrefs.GetInt("TURNED ON NUKE BOMB") == 1 && !reload_completed)
			{

				StartCoroutine(reload(40f));

			}
			if (PlayerPrefs.GetInt("EMP 2") == 1 && PlayerPrefs.GetInt("TURNED ON EMP 2") == 1 && !reload_completed)
			{

				StartCoroutine(reload(30f));

			}
			if (PlayerPrefs.GetInt("GRAVITY BOMB") == 1 && PlayerPrefs.GetInt("TURNED ON GRAVITY BOMB") == 1 && !reload_completed)
			{

				StartCoroutine(reload(30f));

			}
			if (PlayerPrefs.GetInt("INHIBITOR TIME") == 1 && PlayerPrefs.GetInt("TURNED ON INHIBITOR TIME") == 1 && !reload_completed)
			{

				StartCoroutine(reload(25f));

			}
			foreach (GameObject every_upgrade in upgrades)
			{
				every_upgrade.SetActive(false);
			}
		}
	}

	void Update()
	{
		if(Button_share)
		{
			if(PlayerPrefs.GetInt("Reward_complected", 0) == 1)
			{
				if(tut_share != null)
				{
					tut_share.SetActive(false);
				}
				
			}
		}
		if(Button_activate_upgrade && !generate_enemies_for_restart.GetComponent<Generate_enemies>().stop)
		{

			if(PlayerPrefs.GetInt("EMP 1") == 1 && PlayerPrefs.GetInt("TURNED ON EMP 1") == 1)
			{
				upgrades[0].SetActive(true);
				if(reload_completed)
				{
					upgrades[0].GetComponent<Image>().color = new Color(0f/255f, 29f/255f, 255f/255f, 1f);
				} else
				{
					upgrades[0].GetComponent<Image>().color = new Color(0f/255f, 29f/255f, 255f/255f, 0.5f);
					
				}
			}

			if (PlayerPrefs.GetInt("SHOCKWAVE 1") == 1 && PlayerPrefs.GetInt("TURNED ON SHOCKWAVE 1") == 1)
			{
				upgrades[1].SetActive(true);
				if (reload_completed)
				{
					upgrades[1].GetComponent<Image>().color = new Color(0f / 255f, 29f / 255f, 255f / 255f, 1f);
				}
				else
				{
					upgrades[1].GetComponent<Image>().color = new Color(0f / 255f, 29f / 255f, 255f / 255f, 0.5f);
					
				}
			}

			if (PlayerPrefs.GetInt("NUKE BOMB") == 1 && PlayerPrefs.GetInt("TURNED ON NUKE BOMB") == 1)
			{
				upgrades[2].SetActive(true);
				if (reload_completed)
				{
					upgrades[2].GetComponent<Image>().color = new Color(0f / 255f, 29f / 255f, 255f / 255f, 1f);
				}
				else
				{
					upgrades[2].GetComponent<Image>().color = new Color(0f / 255f, 29f / 255f, 255f / 255f, 0.5f);

				}
			}

			if (PlayerPrefs.GetInt("EMP 2") == 1 && PlayerPrefs.GetInt("TURNED ON EMP 2") == 1)
			{
				upgrades[3].SetActive(true);
				if (reload_completed)
				{
					upgrades[3].GetComponent<Image>().color = new Color(98f / 255f, 29f / 255f, 255f / 255f, 1f);
				}
				else
				{
					upgrades[3].GetComponent<Image>().color = new Color(98f / 255f, 29f / 255f, 255f / 255f, 0.5f);

				}
			}

			if (PlayerPrefs.GetInt("GRAVITY BOMB") == 1 && PlayerPrefs.GetInt("TURNED ON GRAVITY BOMB") == 1)
			{
				upgrades[4].SetActive(true);
				if (reload_completed)
				{
					upgrades[4].GetComponent<Image>().color = new Color(98f / 255f, 29f / 255f, 255f / 255f, 1f);
				}
				else
				{
					upgrades[4].GetComponent<Image>().color = new Color(98f / 255f, 29f / 255f, 255f / 255f, 0.5f);

				}
			}

			if (PlayerPrefs.GetInt("INHIBITOR TIME") == 1 && PlayerPrefs.GetInt("TURNED ON INHIBITOR TIME") == 1)
			{
				upgrades[5].SetActive(true);
				if (reload_completed)
				{
					upgrades[5].GetComponent<Image>().color = new Color(255f / 255f, 128f / 255f, 29f / 255f, 1f);
				}
				else
				{
					upgrades[5].GetComponent<Image>().color = new Color(255f / 255f, 128f / 255f, 29f / 255f, 0.5f);

				}
			}


		}
		else if(Button_activate_upgrade && generate_enemies_for_restart.GetComponent<Generate_enemies>().stop)
		{
			foreach (GameObject every_upgrade in upgrades)
			{
				every_upgrade.SetActive(false);
			}
			reload_completed = true;
		}
	}


	public void OnPointerDown(PointerEventData eventData)
	{
		if (Button_activate_upgrade && !generate_enemies_for_restart.GetComponent<Generate_enemies>().stop)
		{
			if (PlayerPrefs.GetInt("EMP 1") == 1 && PlayerPrefs.GetInt("TURNED ON EMP 1") == 1 && reload_completed)
			{
				animations_of_upgrades[0].SetActive(true);
				reload_completed = false;
				StartCoroutine(reload(20f));
				Debug.Log("Turned on");
			}
			if (PlayerPrefs.GetInt("SHOCKWAVE 1") == 1 && PlayerPrefs.GetInt("TURNED ON SHOCKWAVE 1") == 1 && reload_completed)
			{
				animations_of_upgrades[1].SetActive(true);
				reload_completed = false;
				StartCoroutine(reload(30f));
				Debug.Log("Turned on");
			}
			if (PlayerPrefs.GetInt("NUKE BOMB") == 1 && PlayerPrefs.GetInt("TURNED ON NUKE BOMB") == 1 && reload_completed)
			{
				animations_of_upgrades[2].SetActive(true);
				reload_completed = false;
				StartCoroutine(reload(40f));
				Debug.Log("Turned on");
			}
			if (PlayerPrefs.GetInt("EMP 2") == 1 && PlayerPrefs.GetInt("TURNED ON EMP 2") == 1 && reload_completed)
			{
				animations_of_upgrades[3].SetActive(true);
				reload_completed = false;
				StartCoroutine(reload(30f));
				Debug.Log("Turned on");
			}
			if (PlayerPrefs.GetInt("GRAVITY BOMB") == 1 && PlayerPrefs.GetInt("TURNED ON GRAVITY BOMB") == 1 && reload_completed)
			{
				animations_of_upgrades[4].SetActive(true);
				reload_completed = false;
				StartCoroutine(reload(30f));
				Debug.Log("Turned on");
			}
			if (PlayerPrefs.GetInt("INHIBITOR TIME") == 1 && PlayerPrefs.GetInt("TURNED ON INHIBITOR TIME") == 1 && reload_completed)
			{
				animations_of_upgrades[5].SetActive(true);
				reload_completed = false;
				StartCoroutine(reload(25f));
				Debug.Log("Turned on");
			}
		}

		if (Button_pause)
		{

			board_to_turn_on.SetActive(true);
			Time.timeScale = 0f;
			foreach (GameObject every_part in parts_to_turn_off_in_start)
			{
				every_part.SetActive(false);
			}
		}

		if (Button_continue)
		{

			board_to_turn_on.SetActive(true);
			Time.timeScale = 1f;

			foreach (GameObject every_part in parts_to_turn_off_in_start)
			{
				every_part.SetActive(false);
			}
		}

		if (Button_restart)
		{

			board_to_turn_on.SetActive(true);
			generate_enemies_for_restart.GetComponent<Generate_enemies>().stop = false;

			foreach (GameObject every_part in parts_to_turn_off_in_start)
			{
				every_part.SetActive(false);
			}
		}

		if (Button_to_switch_menues)
		{

			board_to_turn_on.SetActive(true);
			
			foreach (GameObject every_part in parts_to_turn_off_in_start)
			{
				if(every_part != null)
				{
					every_part.SetActive(false);
				}
				
			}
		}

		if (Button_menu)
		{
			board_to_turn_on.SetActive(true);
			Time.timeScale = 1f;
			generate_enemies_for_restart.GetComponent<Generate_enemies>().button_pause_pressed = true;
			generate_enemies_for_restart.GetComponent<Generate_enemies>().stop = true;

			foreach (GameObject every_part in parts_to_turn_off_in_start)
			{
				every_part.SetActive(false);
			}
		}

		if (Button_share)
		{
			OnShareClicked();
			if(PlayerPrefs.GetInt("Reward_complected", 0) == 0)
			{
				PlayerPrefs.SetInt("Reward_complected", 1);
				StartCoroutine(reward_for_share());
			}
			




		}

		if (Button_agree)
		{
			PlayerPrefs.SetInt("Agree", 1);
			foreach (GameObject every_agree in for_agree)
			{
				Destroy(every_agree);
			}
		}

		if (Button_language)
		{
			if (!russian)
			{
				PlayerPrefs.SetInt("Russian", 1);
				russian = true;
			}
			else
			{
				PlayerPrefs.SetInt("Russian", 0);
				russian = false;
			}
		}

		if (Button_casino)
		{
			board_to_turn_on.SetActive(true);
			foreach (GameObject every_part in parts_to_turn_off_in_start)
			{
				if (every_part != null)
				{
					every_part.SetActive(false);
				}
			}
		}

		if (Button_spin)
		{
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Normal State"))
			{
				if (PlayerPrefs.GetInt("Money") - 50 >= 0)
				{
					PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
					start_arrow.GetComponent<Roulette_script>().activate = true;
				}
				else
				{
					money_animator.Play("No money");
				}
			}
		}

		if (Button_get_money)
		{
			ShowAD();
		}

		if (Button_back_from_casino)
		{
			if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Normal State") && this.money_animator.GetCurrentAnimatorStateInfo(0).IsName("Simple"))
			{
				board_to_turn_on.SetActive(true);
				foreach (GameObject every_part in parts_to_turn_off_in_start)
				{
					if (every_part != null)
					{
						every_part.SetActive(false);
					}
				}
			}
		}

		if(Button_reward)
		{
			foreach (GameObject every_part in parts_to_turn_off_in_start)
			{
				if (every_part != null)
				{
					every_part.SetActive(false);
				}
			}
		}
	}
	public void OnShareClicked()
	{
#if UNITY_ANDROID
		// Get the required Intent and UnityPlayer classes.
		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		// Construct the intent.
		AndroidJavaObject intent = new AndroidJavaObject("android.content.Intent");
		intent.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		if(PlayerPrefs.GetInt("Russian") == 0)
		{
			intent.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Hey! I am playing in cool game Defase and my best score is " + PlayerPrefs.GetInt("Score", 0).ToString() + ". Can you beat me?\nDOWNLOAD NOW: https://play.google.com/store/apps/details?id=com.LobosRobotics.Defase");
		} else
		{
			intent.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "Привет! Я играю в крутую игру Defase и мой лучший рекорд " + PlayerPrefs.GetInt("Score", 0).ToString() + ". Сможешь ли ты опередить меня?\nСКАЧАЙ СЕЙЧАС: https://play.google.com/store/apps/details?id=com.LobosRobotics.Defase");
		}
		
		intent.Call<AndroidJavaObject>("setType", "text/plain");

		// Display the chooser.
		AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intent, "Share");
		currentActivity.Call("startActivity", chooser);
#endif
	}
	void ShowAD()
	{
		StartCoroutine(Wait_AD());
	}
	void AdCallbackhanler(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("Ad Finished. Rewarding player...");
				PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + Random.Range(175, 300));
				break;
			case ShowResult.Skipped:
				Debug.Log("Ad Skipped");
				break;
			case ShowResult.Failed:
				Debug.Log("Ad failed");
				break;
			
		}
	}
	IEnumerator reload(float time_reload)
	{
		yield return new WaitForSeconds(time_reload);
		reload_completed = true;
	}
	IEnumerator reward_for_share()
	{
		yield return new WaitForSeconds(1.5f);
		if(for_share != null)
		{
			for_share.SetActive(true);
		}
		PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 100);
	}
	IEnumerator Wait_AD()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = AdCallbackhanler;
		while (!Advertisement.IsReady("rewardedVideo")) {}
		
		Advertisement.Show("rewardedVideo", options);
		yield return null;
	}
}
