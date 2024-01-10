using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_every_upgrade : MonoBehaviour
{
	public bool simple_emp = false;
	public bool shockwave = false;
	public bool nuke = false;
	public bool epic_emp = false;
	public bool gravity_trap = false;
	public bool inhibitor_time = false;

	public GameObject for_emp_2;
	GameObject cross;

	void OnEnable()
	{
		cross = GameObject.FindGameObjectWithTag("Cross");
		Debug.Log("Enabled");
		if (simple_emp)
		{
			Debug.Log("Disabling");
			StartCoroutine(turn_off_gameobject(2f));
		}
		if (shockwave)
		{
			Debug.Log("Disabling");
			StartCoroutine(turn_off_gameobject(3f));
		}
		if (nuke)
		{
			Debug.Log("Disabling");
			StartCoroutine(turn_off_gameobject(2f));
		}
		if (epic_emp)
		{
			Debug.Log("Disabling");
			StartCoroutine(turn_off_gameobject(2f));
		}
		if (gravity_trap)
		{
			Debug.Log("Disabling");
			StartCoroutine(turn_off_gameobject(5f));
		}
		if (inhibitor_time)
		{
			Debug.Log("Disabling");
			StartCoroutine(turn_off_gameobject(5f));
		}
	}
	void FixedUpdate()
	{
		if(gravity_trap)
		{
			Vector2 Position = cross.transform.position;
			transform.position = new Vector3(Position.x, Position.y, transform.position.z);
		}
		
	}
    void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Ok");
		if (simple_emp)
		{
			if (other.GetComponent<Enemy_script>() != null)
			{
				Debug.Log("Detected");
				other.GetComponent<Enemy_script>().emp_effect = true;
				other.GetComponent<Enemy_script>().health -= 1f;
				Enemy_script obj = other.GetComponent<Enemy_script>();
				obj.StartCoroutine(obj.turnOff_emp(3f));
			}
		}

		if (nuke)
		{
			if (other.GetComponent<Enemy_script>() != null)
			{
				Debug.Log("Detected");
				other.GetComponent<Enemy_script>().health -= 3f;
			}
		}

		if (epic_emp)
		{
			if (other.GetComponent<Enemy_script>() != null)
			{
				Debug.Log("Detected");
				other.GetComponent<Enemy_script>().emp_effect = true;
				other.GetComponent<Enemy_script>().health -= 2f;
				Enemy_script obj = other.GetComponent<Enemy_script>();
				obj.StartCoroutine(obj.turnOff_emp(5f));
			}
		}
	}

	IEnumerator turn_off_gameobject(float time_disabling)
	{
		if(inhibitor_time)
		{
			Time.timeScale = 0.5f;
		}
		yield return new WaitForSeconds(time_disabling);
		Time.timeScale = 1f;
		if(epic_emp)
		{
			for_emp_2.SetActive(false);
		} else
		{
			gameObject.SetActive(false);
		}
		
	}
}
