using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_in_gameover : MonoBehaviour
{
	public Text score_gameover;
	public float current_score_gameover;
    void Update()
    {
		score_gameover.text = current_score_gameover.ToString();
	}
}
