using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void NewGame()
	{
		SceneManager.LoadScene("Level1");
	}
	
	public void Continue()
	{
		SceneManager.LoadScene("Level1");
	}
	
	public void Exit()
	{
		Application.Quit();
	}
}
