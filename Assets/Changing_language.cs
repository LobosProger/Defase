using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Changing_language : MonoBehaviour
{
	public string text_english;
	public int font_size_english;
	public string text_russian;
	public int font_size_russian;
	public Font english_font;
	public Font russian_font;
	Text to_change_language;
	bool lang_russian = false;
    void Start()
    {
		PlayerPrefs.GetInt("Russian", 0);
		to_change_language = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
		if (PlayerPrefs.GetInt("Russian") == 0)
		{
			lang_russian = false;
		}
		if (PlayerPrefs.GetInt("Russian") == 1)
		{
			lang_russian = true;
		}
		if(!lang_russian)
		{
			to_change_language.text = text_english;
			to_change_language.fontSize = font_size_english;
			to_change_language.font = english_font;
		} else
		{
			to_change_language.text = text_russian;
			to_change_language.fontSize = font_size_russian;
			to_change_language.font = russian_font;
		}
	}
}
