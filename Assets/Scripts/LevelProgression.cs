using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z > 540)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
