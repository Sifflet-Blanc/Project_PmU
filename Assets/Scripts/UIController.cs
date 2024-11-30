using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIController : MonoBehaviour
{
    [System.Serializable]
    public class Map
    {
        public string mapName; // Nom de la map
        public string sceneName; // Nom de la sc�ne correspondante
    }

    public List<Map> maps = new List<Map>(); // Liste des maps
    public GameObject mapButtonTemplate; // Bouton mod�le (template)
    public Transform content; // Conteneur du Scroll View (Content)
    public GameObject levelListPanel;

    void Start()
    {
        Debug.Log("UIController Start() called");
        PopulateMapList();
    }

    void PopulateMapList()
{
    int unlockedLevel = ProgressionManager.GetProgress(); // Obtenir la progression actuelle
    unlockedLevel = Mathf.Min(unlockedLevel, maps.Count); // Empêche unlockedLevel d'excéder maps.Count

    Debug.Log($"Unlocked levels: {unlockedLevel}, Total maps: {maps.Count}");

    for (int i = 0; i < maps.Count; i++) // Boucle sur tous les éléments
    {
        Debug.Log($"Processing map index {i}: {maps[i].mapName}");

        GameObject newButton = Instantiate(mapButtonTemplate, content);
        newButton.SetActive(true);

        // Configurer le texte du bouton avec le nom de la map
        newButton.GetComponentInChildren<Text>().text = maps[i].mapName;

        // Vérifier si le niveau est débloqué
        Button button = newButton.GetComponent<Button>();
        if (i + 1 > unlockedLevel)
        {
            button.interactable = false; // Désactiver le bouton si le niveau est verrouillé
            Debug.Log($"Level {i + 1} ({maps[i].mapName}) is locked.");
        }
        else
        {
            int levelIndex = i; // Stocker une copie locale pour éviter les problèmes de portée
            button.onClick.AddListener(() => LoadMap(maps[levelIndex].sceneName));
            Debug.Log($"Level {i + 1} ({maps[i].mapName}) is unlocked.");
        }
    }
}


    public void LoadMap(string sceneName)
    {
        // Charger la sc�ne de la map
        SceneManager.LoadScene(sceneName);
    }

    public void OpenLevelList()
    {
        levelListPanel.SetActive(!levelListPanel.activeSelf); // Alterne l'affichage du Panel
    }
}
