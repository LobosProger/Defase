using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_plasma_bullet : MonoBehaviour
{
	public float speed;
	void Start()
    {
		StartCoroutine(destroy());
		
    }
    void FixedUpdate()
    {
		transform.position += transform.up * Time.deltaTime * speed;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			other.GetComponent<Enemy_script>().health -= 1f;
			Destroy(gameObject);
		}
	}
	IEnumerator destroy()
	{
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
