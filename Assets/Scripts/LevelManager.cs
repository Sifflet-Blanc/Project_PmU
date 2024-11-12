using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public string sceneName;
    // Start is called before the first frame update
    
    void Start()
    {
        // Initialiser le nombre d'ennemis vivants
        enemiesAlive = FindObjectsOfType<EnemyBehaviour>().Length;
    }

    public void OnEnemyDeath()
    {
        enemiesAlive--;
        
        if (enemiesAlive <= 0)
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneName);
    }




}
