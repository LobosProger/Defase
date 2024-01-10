using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Best_score : MonoBehaviour
{
	public Text best_cur_score;
	
	void Start()
	{
		best_cur_score.text = PlayerPrefs.GetInt("Score", 0).ToString();
	}

    void Update()
    {
		best_cur_score.text = PlayerPrefs.GetInt("Score", 0).ToString();
	}
}
