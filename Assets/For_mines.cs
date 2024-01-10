using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_mines : MonoBehaviour
{
	bool boomed_mine = false;
	public GameObject boom_mine;
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			if (!boomed_mine)
			{
				boomed_mine = true;
				StartCoroutine(destroy_mine());
			}
		}
	}
	IEnumerator destroy_mine()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
		boom_mine.SetActive(true);
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
