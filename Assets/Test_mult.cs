using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test_mult : MonoBehaviour
{
	private float speed = 5f;
	public Rigidbody2D rb;
	// Update is called once per frame
	void FixedUpdate()
	{
		
			float movement = Input.GetAxis("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed, 0.0f);
		
	}
}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Moving : NetworkBehaviour
{
	private float speed = 5f;
	public Rigidbody2D rb;
	// Update is called once per frame
	void FixedUpdate()
	{
		if (this.isLocalPlayer)
		{
			float movement = Input.GetAxis("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed, 0.0f);
		}
	}
}
*/
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MoveShip : NetworkBehaviour
{
	[SerializeField]
	private float speed = 5f;

	void FixedUpdate()
	{
		if (this.isLocalPlayer)
		{
			float movement = Input.GetAxis("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2(movement * speed, 0.0f);
		}
	}
}*/
