using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Objective
{
    public string description;
    public bool isCompleted;
}

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject objectivesPanel;
    public Text objectivesText,objectivesText1;

    public List<Objective> objectivesList;

    private bool isPaused = false;

    void Start()
    {
        ResumeGame();
                UpdateObjectivesText();

    }

   
   public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pauseMenu.SetActive(true);
        UpdateObjectivesText();
        objectivesPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        pauseMenu.SetActive(false);
        objectivesPanel.SetActive(false);
    }

    void UpdateObjectivesText()
    {
        if (objectivesList != null && objectivesList.Count > 0)
        {
            string objectivesString = "Objectives:\n";
            for (int i = 0; i < objectivesList.Count; i++)
            {
                objectivesString += $"{i + 1}. {objectivesList[i].description}";

                if (objectivesList[i].isCompleted)
                {
                    objectivesString += " ✔";
                }

                objectivesString += "\n";
            }
            objectivesText.text = objectivesString;
            objectivesText1.text = objectivesString;
        }
        else
        {
            objectivesText.text = "No objectives available.";
        }
    }

    public void SetObjectives(List<Objective> newObjectives)
    {
        objectivesList = newObjectives;
        UpdateObjectivesText();
    }

    public void HideObjectives()
    {
        objectivesPanel.SetActive(false);
    }

    public void QuitGame()
    {
        // Add code to save progress or handle any other necessary tasks
        Application.Quit();
    }

    public void MainMenu()
    {
        // Add code to save progress or handle any other necessary tasks
       SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
