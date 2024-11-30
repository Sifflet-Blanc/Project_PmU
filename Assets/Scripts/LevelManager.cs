using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public static LevelManager instance;
    private EndGameController controller;

    void Start()
    {
        enemiesAlive = FindObjectsOfType<EnemyBehaviour>().Length;
        // Assure-toi que EndGameController est attaché à un GameObject dans la scène
        controller = FindObjectOfType<EndGameController>();
        if (controller == null)
        {
            Debug.LogError("EndGameController is not found in the scene!");
        }
    }


    public void OnEnemyDeath()
    {
        enemiesAlive--;

        if (enemiesAlive <= 0)
        {
            controller?.Victory();

            // Débloquer le niveau suivant
            int currentLevel = SceneManager.GetActiveScene().buildIndex; // Index du niveau actuel
            ProgressionManager.UnlockLevel(currentLevel + 1); // Débloque le niveau suivant
        }
    }


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Supprime cet objet si une autre instance existe
            return;
        }

        instance = this;
    }


    public void OnPlayerDeath()
    {
       controller.Defeat();
    }




}
