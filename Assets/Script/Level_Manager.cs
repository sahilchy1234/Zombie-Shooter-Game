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
    [Header("Not Necessary Except Level 5 and 6")]
    public GameObject finalCutScene;
    public GameObject wave3Zombie;
    public GameObject detonatorShowingCanvas;

    [Header("Need Assigned for all Levels some Excluded for level 1")]
    public GameObject wave2Zombie;
    public GameObject player;
    public GameObject deathPanel;
    public string nextLevelName;
    public GameObject controlPanel;
    public GameObject playerCanvas;
    public GameObject completePanel;
    public int targetKills;
    public TMP_Text[] killText;
    public int kills;
    public static Level_Manager instance;
    private string sceneName;

    void Start()
    {
        instance = this;
        Scene scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    bool ss;
    void Update()
    {
        UpdateKillText();

        if (kills >= targetKills)
        {
            UpdateTargetKillsAndActivateZombies();
        }

        if (kills >= 34 && ss == false)
        {

            if (detonatorShowingCanvas != null)
            {
                detonatorShowingCanvas.SetActive(true);
                ss = true;
            }
        }
    }

    void UpdateKillText()
    {
        foreach (var text in killText)
        {
            text.text = kills.ToString();
        }
    }

    private bool ik = false;


    void UpdateTargetKillsAndActivateZombies()
    {

        if (kills >= targetKills)
        {

            if (sceneName == "Level 2" || sceneName == "Level 3" || sceneName == "Level 4")
            {
                wave2Zombie.SetActive(true);
                targetKills = 22;
            }

            if ((sceneName == "Level 5" || sceneName == "Level 6") && kills >= targetKills)
            {
                if (ik)
                {
                    targetKills = 34;
                    wave3Zombie.SetActive(true);
                }

                if (!ik)
                {
                    targetKills = 22;
                    wave2Zombie.SetActive(true);
                    ik = true;
                }
            }

            CompleteLevel();
        }
    }

    void CompleteLevel()
    {


        if (sceneName == "Level 1" || (sceneName == "Level 2" && HostageManager.instance.isRescueCompleted) ||
            (sceneName == "Level 3" && HostageManager.instance.isRescueCompleted) ||
            (sceneName == "Level 4" && HostageManager.instance.isRescueCompleted) ||
            (sceneName == "Level 5" && HostageManager.instance.isRescueCompleted))
        {
            PlayerPrefs.SetInt(nextLevelName, 1);
            completePanel.SetActive(true);
            controlPanel.SetActive(false);
            playerCanvas.SetActive(false);
        }

        if (sceneName == "Level 6" && HostageManager.instance.isRescueCompleted)
        {
            PlayerPrefs.SetInt(nextLevelName, 1);
            finalCutScene.SetActive(true);
            Invoke("MainFun", 4f);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
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

    void MainFun()
    {
        completePanel.SetActive(true);
        controlPanel.SetActive(false);
        playerCanvas.SetActive(false);
    }


}
