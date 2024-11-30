using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    private const string ProgressKey = "LevelProgress"; // Clé pour sauvegarder la progression

    public void Start()
    {
        ResetProgress();
    }

    // Débloquer un niveau
    public static void UnlockLevel(int levelIndex)
    {
        int currentProgress = GetProgress();

        if (levelIndex > currentProgress)
        {
            PlayerPrefs.SetInt(ProgressKey, levelIndex); // Sauvegarde la progression
            PlayerPrefs.Save();
        }
    }

    // Obtenir la progression actuelle
    public static int GetProgress()
    {
        return PlayerPrefs.GetInt(ProgressKey, 1); // Retourne 1 par défaut (seul le premier niveau est débloqué)
    }

    // Réinitialiser la progression (optionnel, pour debug ou test)
    public static void ResetProgress()
    {
        PlayerPrefs.SetInt(ProgressKey, 1); // Réinitialise au premier niveau
        PlayerPrefs.Save();
    }
}

