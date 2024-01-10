using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class To_fix_current_score : MonoBehaviour
{
	
	public int current_score;
	public Text score;
	
	
	void Update()
	{
		/*if (game_over)
		{
			if (!shown_gameover)
			{
				score.text = current_score.ToString();
				shown_gameover = true;
			}
		}
		else
		{
			score.text = current_score.ToString();
		}*/
		score.text = current_score.ToString();
	}
}
