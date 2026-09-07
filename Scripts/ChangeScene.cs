using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [Header("UI UI Elements")]
    [SerializeField] private GameObject loadingScreenPanel; // Loading animation
    [SerializeField] private Image loadingBarImage;           // Progress bar
	[Header("Settings")]
    [SerializeField] private float fillSpeed = 1.5f;

    public void ProgressToScene(int sceneID)
    {
		// Start loading routine in background
        StartCoroutine(LoadSceneAsyncCoroutine(sceneID)); 
    }
	private IEnumerator LoadSceneAsyncCoroutine(int sceneID)
    {
        // Display loading screen
        if (loadingScreenPanel != null)
		{
            loadingScreenPanel.SetActive(true);
		}
		
		// Set loading bar to 0%
		if (loadingBarImage != null)
		{
			loadingBarImage.fillAmount = 0f;
		}
        // Start asynchronous loading of scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
		operation.allowSceneActivation = false; 
		
		// Smooth progress of loading to 90%
		while (loadingBarImage.fillAmount < 0.9f)
		 {
            float target = Mathf.Clamp(operation.progress / 0.9f, 0f, 0.9f);
            loadingBarImage.fillAmount = Mathf.MoveTowards(loadingBarImage.fillAmount, target, fillSpeed * Time.unscaledDeltaTime);
            yield return null;
        }
		
		// Stop bar at 90% and wait for background operation to be completed
        while (operation.progress < 0.9f)
        {
            yield return null; 
        }
		
		Shader.WarmupAllShaders();
		
		// When complete, simulate smooth progress from 90% to 100%
        while (loadingBarImage.fillAmount < 1f)
        {
            loadingBarImage.fillAmount = Mathf.MoveTowards(loadingBarImage.fillAmount, 1f, (fillSpeed * 3f) * Time.unscaledDeltaTime);
            yield return null;
        }
		
		// When loading bar hits 100%, instant scene change
        operation.allowSceneActivation = true;
		
    }

	public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
	
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadStructMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadARScene()
    {
        SceneManager.LoadScene(2);
    }
}