using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
	[SerializeField] RawImage deathImage;
	BoxCollider boxCollider;
	Color32 deathImageColor;
	
	public static bool dead = false;
	private int deathImageFade = 1000;
	
	void Awake()
	{
		deathImage.enabled = false;
		boxCollider = GetComponent<BoxCollider>();
		deathImageColor = new Color32(255, 255, 255, 255);
	}
	
	void Update()
	{
		if (transform.position.y < -2)  // check if player falls off platform
			Dead(1.0f);
		
		if (ColonelSanders.z > transform.position.z)  // check if colonel sanders is further than player
			Dead(1.5f);
		
		// fade death screen
		if (dead)
		{
			if (deathImageColor.a - deathImageFade * Time.deltaTime > 1)
				deathImageColor.a -= (byte)(deathImageFade * Time.deltaTime);

			deathImage.color = deathImageColor;
		}
		
	}
	
    void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.CompareTag("Enemy"))  // detects if player collides with the side of an enemy
			Dead(1.5f);
	}
	
	void Dead(float time)  // player will fall through floor and level will reset in 2 seconds
	{
		if (!dead)
		{
			deathImage.enabled = true;

			Destroy(boxCollider);
			StartCoroutine(Reset(time));
			
			dead = true;
		}
	}
	
	IEnumerator Reset(float time)  // reset level after two seconds
	{
		yield return new WaitForSeconds(time);
		dead = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
