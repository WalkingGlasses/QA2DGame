using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneScript : MonoBehaviour
{
    public TextMeshProUGUI textMeshProField;

    public GameObject[] Scenes;
    public int ActiveScene;

    // Start is called before the first frame update
    void Start()
    {
        Scenes[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitGame()
    {
        // Exit the application
        Application.Quit();

        // Note: The Quit method works in standalone builds, not in the Unity Editor.
        // In the Unity Editor, you might want to use UnityEditor.EditorApplication.isPlaying to stop play mode.
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void SceneChanger()
    {
        ActiveScene = 0; // Change to the index of the canvas you want to activate
        for (int i = 0; i < Scenes.Length; i++)
        {
            Scenes[i].SetActive(i == ActiveScene);
        }
    }

    public void StartButton()
    {
        Scenes[0].SetActive(false);
        Scenes[1].SetActive(true);
    }

    public void ScissorButton()
    {
        Scenes[1].SetActive(false);
        Scenes[2].SetActive(true);
    }

    public void BurnRopeButton()
    {
        Scenes[1].SetActive(false);
        Scenes[2].SetActive(false);
        Scenes[3].SetActive(true);
    }

    public void SneakPastButton()
    {
        // Check if the index is within the valid range
        if (Scenes.Length > 5)
        {
            Scenes[3].SetActive(false);
            Scenes[5].SetActive(true);
        }
        else
        {
            Debug.LogError("Array length is less than 6. Unable to access Scenes[5].");
        }
    }

    public void StealthTakedownButton()
    {
        // Check if the index is within the valid range
        if (Scenes.Length > 4)
        {
            Scenes[3].SetActive(false);
            Scenes[4].SetActive(true);
        }
        else
        {
            Debug.LogError("Array length is less than 5. Unable to access Scenes[4].");
        }
    }

}
