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
	private Vector3 deathVelocity;

	private float jumpForce = 8.5f;
	private float speed = 14.0f;
	private float decSpeed = 10.0f;
	private float deathDecSpeed = 1.0f;
	
	private bool justDied = false;
	
    void Start()
    {
		body = GetComponent<Rigidbody>();
		zero = new Vector3(0, 0, 0);
    }

    void Update()
    {
        velocity = body.velocity;

		// get velocity when player dies
		if (PlayerDeath.dead && !justDied)
		{
			deathVelocity = velocity;
			justDied = true;
		}
		
		else if (PlayerDeath.dead)
		{
			deathVelocity.y = velocity.y;  // update y velocity
			
			deathVelocity.x = deathVelocity.x / (1 + deathDecSpeed * Time.deltaTime);
			deathVelocity.z = deathVelocity.z / (1 + deathDecSpeed * Time.deltaTime);
			
			velocity = deathVelocity;
		}
		
		// movement
		if (Input.GetKeyDown("space") && Physics.CheckSphere(groundCheck.position, 0.65f, ground) && !PlayerDeath.dead)
			velocity.y = jumpForce;

		velocity.x = (Input.GetKey("a") || Input.GetKey("j")) && !PlayerDeath.dead ? speed * -1 : (Input.GetKey("d") || Input.GetKey("l")) && !PlayerDeath.dead ? speed : velocity.x / (1 + decSpeed * Time.deltaTime);
		velocity.z = (Input.GetKey("s") || Input.GetKey("k")) && !PlayerDeath.dead ? speed * -1 : (Input.GetKey("w") || Input.GetKey("i")) && !PlayerDeath.dead ? speed : velocity.z / (1 + decSpeed * Time.deltaTime);

		// update rigid body velocity
		body.velocity = velocity;
    }
}
