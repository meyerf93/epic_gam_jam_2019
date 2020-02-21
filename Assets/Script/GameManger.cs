using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
	public static GameManger Instance;
    


	public void loadLevel()
	{
        StartCoroutine(LoadSceneDelayed("Level", 0.5f));
  	}

	public void loadFin()
	{
        StartCoroutine(LoadSceneDelayed("Fin", 1f));
	}
    
	public void loadTitre()
	{
		StartCoroutine(LoadSceneDelayed("Titre", 0.5f));
	}

	public void exitGame()
	{
		Application.Quit();
	}

    IEnumerator LoadSceneDelayed(string sceneName, float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }
}