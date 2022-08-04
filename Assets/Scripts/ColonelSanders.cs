using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonelSanders : MonoBehaviour
{
	private Vector3 scale;
	
    private float speed = 12.85f;
	private float expand = 0.25f;

	public static float z;
	
	void Awake()
	{
		z = transform.position.z;
		scale = transform.localScale;
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);  // set z velocity of body to speed
	}
	
	void Update()
	{
		z = transform.position.z;
		
		scale.x += expand * Time.deltaTime;
		scale.y += expand * Time.deltaTime;
		scale.z += expand * Time.deltaTime;
		
		transform.localScale = scale;
	}
}
