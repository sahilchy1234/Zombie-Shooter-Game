using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using AuroraFPSRuntime.SystemModules.ControllerSystems;

using AuroraFPSRuntime.Attributes;
using UnityEngine;
using AuroraFPSRuntime;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public GameObject player;
    public GameObject deathPanel;
    public string NextLevelName;
    public GameObject controlPanel;
    public GameObject PlayerCanvas;
    public GameObject CompletePanel;
    public int TargetKills;
    public TMP_Text[] killText;
    public int kills;
    public static Level_Manager instance;
    private string scene_name;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Scene scene = SceneManager.GetActiveScene();
        scene_name = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < killText.Length; i++)
        {
            killText[i].text = kills.ToString();
        }

        if (kills >= TargetKills)
        {
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        if (scene_name == "Level 1")
        {
            CompletePanel.SetActive(true);
            controlPanel.SetActive(false);
            PlayerCanvas.SetActive(false);
        }
        else
        {

            if (scene_name == "Level 2")
            {
                if (HostageManager.instance.isRescueCompleted)
                {
                    CompletePanel.SetActive(true);
                    controlPanel.SetActive(false);
                    PlayerCanvas.SetActive(false);
                }
            }
        }
    }

    public void nextLevel()
    {
        Application.LoadLevel(NextLevelName);
    }

    public void RestartLevel()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void StartDeathFunctions()
    {
        Invoke("MainDeath", 2f);
    }

    void MainDeath()
    {
        player.GetComponent<FPHealth>().enabled = false;
        player.GetComponent<PlayerRigidbodyController>().enabled = false;

        deathPanel.SetActive(true);
    }
}
