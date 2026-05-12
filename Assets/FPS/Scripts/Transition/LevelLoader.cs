using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("Scene to load when objective is complete")]
    public string nextSceneName = "Level_02";

    [Header("Delay before loading next scene (seconds)")]
    public float loadDelay = 3f;

    private bool hasTriggered = false;

    void Update()
    {
        // Check if all enemies in the scene are destroyed
        GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (remainingEnemies.Length == 0 && !hasTriggered)
        {
            hasTriggered = true;
            Debug.Log("All enemies defeated! Loading next level...");
            Invoke(nameof(LoadNextLevel), loadDelay);
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}