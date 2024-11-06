using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Required for scene management

public class ButtonClickHandler : MonoBehaviour
{
    private void Start()
    {
        // It's safe to call GetActiveScene here
        Scene currentScene = SceneManager.GetActiveScene();  // Get the active scene

        // You can add any initialization logic here if needed
        Debug.Log("Current scene name: " + currentScene.name);
    }

    // This method can be triggered by button click
    public void OnButtonClicked()
    {
        Debug.Log("Button was clicked!");
        // Add functionality to switch to the next scene here
        SwitchToNextScene();
    }

    // Method to switch to the next scene
    public void SwitchToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene by index, check if it exists
        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("No next scene available.");
        }
    }
}