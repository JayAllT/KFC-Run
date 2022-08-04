using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Transform groundCheck;
	[SerializeField] LayerMask ground;
	
	Rigidbody body;

	private Vector3 velocity;
	private Vector3 zero;

	private float jumpForce = 8.5f;
	private float speed = 14.0f;
	private float decSpeed = 10.0f;
	
    void Start()
    {
		body = GetComponent<Rigidbody>();
		zero = new Vector3(0, 0, 0);
    }

    void Update()
    {
        velocity = body.velocity;
		
		if (Input.GetKeyDown("space") && Physics.CheckSphere(groundCheck.position, 0.5f, ground))
			velocity.y = jumpForce;
		
		velocity.x = Input.GetKey("left") ? speed * -1 : Input.GetKey("right") ? speed : velocity.x / (1 + decSpeed * Time.deltaTime);
		velocity.z = Input.GetKey("down") ? speed * -1 : Input.GetKey("up") ? speed : velocity.z / (1 + decSpeed * Time.deltaTime);

		body.velocity = velocity;
    }
}
