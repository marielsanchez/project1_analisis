using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{

	public Button game;
	public Button sol;
	public Button quit;
	
	void Start()
	{
        
	}
	
	public void changeSceneGame(){
		SceneManager.LoadScene("NonogramGame");
	}
	
	public void changeSceneSolution(){
		SceneManager.LoadScene("NonogramSolution");
	}
	
	public void QuitGameFuntion()
	{
		Application.Quit();
		Debug.Log("Se ha salido del juego");

	}
}
