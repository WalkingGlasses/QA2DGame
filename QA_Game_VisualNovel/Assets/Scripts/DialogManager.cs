using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogText;
    public string[] dialogLines;
    private int currentLine = 0;

    public GameObject[] choiceButtons; // Array of buttons to be revealed after dialog ends

    void Start()
    {
        // Ensure the array is not empty before showing the initial dialog line
        if (dialogLines.Length > 0)
        {
            // Hide the choice buttons at the start
            HideChoiceButtons();

            // Show the initial dialog line
            ShowCurrentDialogLine();
        }
        else
        {
            Debug.LogError("Dialog lines array is empty. Please populate it in the Unity Inspector.");
        }
    }

    void Update()
    {
        // Example: Progress to the next line when the player presses a button (e.g., space key)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogLine();
        }
    }

    void NextDialogLine()
    {
        // Check if there are more lines of dialog
        if (currentLine < dialogLines.Length - 1)
        {
            currentLine++;
            ShowCurrentDialogLine();
        }
        else
        {
            // No more lines - you can handle the end of the dialog here
            Debug.Log("End of dialog");

            // Show the choice buttons
            ShowChoiceButtons();
        }
    }

    void ShowCurrentDialogLine()
    {
        // Hide the previous dialog line
        dialogText.enabled = false;

        // Show the current dialog line
        dialogText.text = dialogLines[currentLine];
        dialogText.enabled = true;
    }

    void ShowChoiceButtons()
    {
        // Show each choice button in the array
        foreach (GameObject button in choiceButtons)
        {
            button.SetActive(true);
        }
    }

    void HideChoiceButtons()
    {
        // Hide each choice button in the array
        foreach (GameObject button in choiceButtons)
        {
            button.SetActive(false);
        }
    }

    public void StartNewDialog()
    {
        currentLine = 0;
        HideChoiceButtons();

        // Check if there are any dialog lines before trying to display
        if (currentLine < dialogLines.Length)
        {
            ShowCurrentDialogLine();
        }
        else
        {
            Debug.LogError("No dialog lines available.");
        }
    }
}
