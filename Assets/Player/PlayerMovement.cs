﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float speed;
	private Rigidbody2D rb;
	Vector2 movement = new Vector2();

	void Start()
	{
		Debug.Log("Funciona");
		rb = GetComponent<Rigidbody2D>();
    }

	private void Update()
	{

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		movement = new Vector2(moveHorizontal, moveVertical);
	}

	void FixedUpdate()
    {
		rb.velocity = (movement * speed);
	}

	public void SavePlayer()
	{
		SaveSystem.SavePlayer(this);
	}

	public void LoadPlayer()
	{
		PlayerData data = SaveSystem.LoadPlayer();

		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];

		transform.position = position;
	}

}
