using UnityEngine;
/*using UntyEngine.SceneManagement;*/

public class GameOverManager : MonoBehaviour
{
    
    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is no more instance of GameOverManager in this scene");
            return;
        }

        instance = this;
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    /*public void RetryButton()
    {
        //Recommencer le niveau
        //Recharge la scène
        *//*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*//*
        //Replace le joueur au spawn
        //Réactive les mouvements du joueur + qu'on lui rende sa vie
        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }*/
}
