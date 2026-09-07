using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdvancedSceneLoader : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject loadingScreenPanel; // Loading animation
    public Image loadingProgressBar; // Drag your Filled Image here in the Inspector

    public void LoadNewScene(int sceneID)
    {
        StartCoroutine(LoadSceneAdditiveRoutine(sceneID));
    }

    private IEnumerator LoadSceneAdditiveRoutine(int targetSceneID)
    {
        // Store the current loading scene build index before loading the new one
        int currentLoadingSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // 1. Reduce background loading priority to prevent Unity from freezing the UI
        Application.backgroundLoadingPriority = ThreadPriority.Low;

        // Display loading screen
        if (loadingScreenPanel != null)
        {
            loadingScreenPanel.SetActive(true);
        }

        // Reset progress bar visual
        if (loadingProgressBar != null)
        {
            loadingProgressBar.fillAmount = 0f;
        }

        // 2. Load the target scene asynchronously in Additive mode using its ID
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(targetSceneID, LoadSceneMode.Additive);

        while (!loadOperation.isDone)
        {
            // Update the UI image fill amount based on progress (0.0 to 1.0)
            if (loadingProgressBar != null)
            {
                loadingProgressBar.fillAmount = loadOperation.progress;
            }
            yield return null;
        }

        // Force progress to 100% once loading is officially complete
        if (loadingProgressBar != null)
        {
            loadingProgressBar.fillAmount = 1f;
        }

        // Not useful for default Renderer Pipeline, activate for URP
        // Shader.WarmupAllShaders();

        // 3. Set the newly loaded scene as the active one using its ID
        Scene targetScene = SceneManager.GetSceneByBuildIndex(targetSceneID);
        SceneManager.SetActiveScene(targetScene);

        // 4. Wait for the end of the frame to let Awake() and Start() methods execute smoothly
        yield return new WaitForEndOfFrame();

        // Restore default loading priority for the rest of the game
        Application.backgroundLoadingPriority = ThreadPriority.Normal;

        // 5. Unload the loading scene completely from memory using its stored index
        SceneManager.UnloadSceneAsync(currentLoadingSceneIndex);
    }
}