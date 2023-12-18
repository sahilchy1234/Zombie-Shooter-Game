using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialongM : MonoBehaviour
{
    public TMP_Text[] text;
    private int currentIndex;

    public GameObject controlsPanel;
    public Animator dialogPanelAnimator;
    public GameObject secondPanel;
    public GameObject headshotPanel;

    private bool gunPickedUp;

    public static DialongM instance;

   
     void Awake()
    {
        instance = this;
    }

    public void NextFunction()
    {
        if (currentIndex == 1 || currentIndex == 3)
        {
            HideDialogPanel();
            controlsPanel.SetActive(true);
        }

        if (secondPanel.activeSelf)
        {
            secondPanel.SetActive(false);
        }

        if (currentIndex <= 1)
        {
            text[currentIndex].gameObject.SetActive(false);
            currentIndex++;
            text[currentIndex].gameObject.SetActive(true);
        }
    }

    public void afterGunPickUp()
    {
        if (!gunPickedUp)
        {
            gunPickedUp = true;
            secondPanel.SetActive(true);
        }
    }

    private void HideDialogPanel()
    {
        dialogPanelAnimator.Play("Hide");
        dialogPanelAnimator.gameObject.SetActive(false);
    }


   public void tutorialHeadshot(){
      Time.timeScale = 0.1f;
      headshotPanel.SetActive(true);
    } 
}
