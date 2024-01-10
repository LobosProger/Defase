using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Money : MonoBehaviour
{
	Text counts_of_money;
    void Start()
    {
		counts_of_money = gameObject.GetComponent<Text>();
    }

    void Update()
    {
		counts_of_money.text = PlayerPrefs.GetInt("Money", 0).ToString();
    }
}
