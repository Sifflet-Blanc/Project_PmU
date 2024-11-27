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
        public string sceneName; // Nom de la scène correspondante
    }

    public List<Map> maps = new List<Map>(); // Liste des maps
    public GameObject mapButtonTemplate; // Bouton modèle (template)
    public Transform content; // Conteneur du Scroll View (Content)
    public GameObject levelListPanel;

    void Start()
    {
        Debug.Log("UIController Start() called");
        PopulateMapList();
    }

    void PopulateMapList()
    {
        float spacing = 50f; // Espacement vertical entre les boutons
        float currentY = 0f; // Position initiale

        foreach (Map map in maps)
        {
            GameObject newButton = Instantiate(mapButtonTemplate, content);
            newButton.SetActive(true);

            // Configurer le texte
            newButton.GetComponentInChildren<Text>().text = map.mapName;

            // Définir la position
            RectTransform rectTransform = newButton.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, currentY);

            // Ajouter un listener
            newButton.GetComponent<Button>().onClick.AddListener(() => LoadMap(map.sceneName));

            // Ajuster pour le prochain bouton
            currentY -= spacing; // Descendre pour le prochain bouton
        }
    }


    public void LoadMap(string sceneName)
    {
        // Charger la scène de la map
        SceneManager.LoadScene(sceneName);
    }

    public void OpenLevelList()
    {
        levelListPanel.SetActive(!levelListPanel.activeSelf); // Alterne l'affichage du Panel
    }
}
