using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
private Rigidbody rb; 
private float movementX;
private float movementY;
private float jumpAmount = 7;

private bool onAir = true;
private bool win = false;
private float speed = 3; 

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
 
	void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();
		movementX = movementVector.x; 
		movementY = movementVector.y; 
	}

	private void FixedUpdate() 
	{
		if (Input.GetKeyDown(KeyCode.Space) && !onAir)
		{
			rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
			onAir = true;
		}
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);
		rb.AddForce(movement * speed);
	}

	private	void OnCollisionEnter(Collision collision)
	{
		// if (win == false) {
			if (collision.gameObject.tag == "Lava")
			{
				Destroy(gameObject);
				Debug.Log("Game Over");
			}
			else if (collision.gameObject.tag == "Path")
				onAir = false;
			else if (collision.gameObject.tag == "win") {
				// win = true;
				onAir = false;
				Debug.Log("You Win");
			}
		// }
	}
}