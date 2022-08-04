using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColonelSanders : MonoBehaviour
{
    private float speed = 12.0f;
	
	void Awake()
	{
		GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed);  // set z velocity of body to speed
	}
}
