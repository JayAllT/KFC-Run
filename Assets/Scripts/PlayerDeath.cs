using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
	BoxCollider boxCollider;
	
	void Awake()
	{
		boxCollider = GetComponent<BoxCollider>();
	}
	
	void Update()
	{
		if (transform.position.y < -2)
			Dead(1);
		
		if (ColonelSanders.z > transform.position.z)
			Dead(2);
	}
	
    void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Enemy"))  // detects if player collides with the side of an enemy
			Dead(2);
	}
	
	void Dead(int time)  // player will fall through floor and level will reset in 2 seconds
	{
		Destroy(boxCollider);
		StartCoroutine(Reset(time));
	}
	
	IEnumerator Reset(int time)  // reset level after two seconds
	{
		yield return new WaitForSeconds(time);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
