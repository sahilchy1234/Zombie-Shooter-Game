using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialongM : MonoBehaviour
{

    public TMP_Text[] text;
    int i;

    public GameObject Controls;

    public Animator dialogPanelAnim;

    public GameObject SecondPanel;

   public void NextFunction()
    {


     
            if (i == 1)
            {
                dialogPanelAnim.Play("Hide");
                  dialogPanelAnim.gameObject.SetActive(false);
                Controls.SetActive(true);
            }
            if (i == 3)
            {
                dialogPanelAnim.Play("Hide");
                dialogPanelAnim.gameObject.SetActive(false);
                Controls.SetActive(true);
            }
            if(SecondPanel.activeSelf){
                SecondPanel.SetActive(false);
            }
            if (i <= 1)
            {
                text[i].gameObject.SetActive(false);
                i++;
                text[i].gameObject.SetActive(true);
            }

    }
    bool k;
    public void afterGunPickUp()
    {


        if (!k)
        {

            k = true;
          SecondPanel.SetActive(true);
        }
    }
}
