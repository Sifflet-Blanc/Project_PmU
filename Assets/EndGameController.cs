using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public GameObject victoryPanel;
    public GameObject defeatPanel;

    public void Victory()
    {
        victoryPanel.SetActive(true);
    }
    public void Defeat()
    {
        defeatPanel.SetActive(true);
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene("BaseMap");
    }

    public void QuitGame()
    {
        QuitGame();
    }
}
