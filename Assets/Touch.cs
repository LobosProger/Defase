using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
	public bool Touch_detected = false;
	int number_of_touch;
	bool touched = false;
	float real_time_of_touch;
	public GameObject[] cross;
	
	bool completed_two_touches = false;
	float real_time_of_completed_two_touches;
	
    void Update()
    {
		PlayerPrefs.GetInt("Upgraded cross", 0);
		if (PlayerPrefs.GetInt("Upgraded cross", 0) == 0)
		{
			cross[0].SetActive(true);
			cross[1].SetActive(false);
		}
		else
		{
			cross[0].SetActive(false);
			cross[1].SetActive(true);
		}
		if (!completed_two_touches)
		{
			if (!Touch_detected)
			{

				for (var i = 0; i < Input.touchCount; i++) //ФУНКЦИЯ ОБРАБОТКИ НАЖАТИЯ
				{
					if (Input.GetTouch(i).phase == TouchPhase.Began && !touched)
					{

						number_of_touch = i;
						touched = true;
					}
					if (touched && Input.GetTouch(number_of_touch).phase == TouchPhase.Ended)
					{

						Touch_detected = true;
						real_time_of_touch = Time.fixedTime;
					}
				}
			}
			if (Touch_detected)
			{
				if (Time.fixedTime - real_time_of_touch < 0.25f)
				{
					for (var i = 0; i < Input.touchCount; i++) //ФУНКЦИЯ ОБРАБОТКИ НАЖАТИЯ
					{
						if (Input.GetTouch(i).phase == TouchPhase.Began && touched)
						{

							number_of_touch = i;
							touched = false;
						}
						if (!touched && Input.GetTouch(number_of_touch).phase == TouchPhase.Ended)
						{
							foreach(GameObject every_cross in cross)
							{
								if (every_cross.active)
								{
									every_cross.GetComponent<Moving_of_cross>().Shoot();
								}
							}
							
							Touch_detected = false;
							touched = false;
							completed_two_touches = true;
							real_time_of_completed_two_touches = Time.fixedTime;
						}
					}
				}
				else
				{
					Touch_detected = false;
					touched = false;
				}
			}
		} else
		{
			if(Time.fixedTime - real_time_of_completed_two_touches > 0.05f)
			{
				completed_two_touches = false;
			}
		}
	}
}
