using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    GameStatus gamestatus;

	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        gamestatus = FindObjectOfType<GameStatus>();

        SceneManager.LoadScene(0);
        gamestatus.DestroySelf();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
