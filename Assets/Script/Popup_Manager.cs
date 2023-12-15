using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Popup_Manager : MonoBehaviour
{
    public static Popup_Manager instance;
    public Text messageText;
    public GameObject popUp;

    void Awake(){
        instance = this;
    }

    public void ShowPopupMessage(string message) {
        messageText.text= message;
        popUp.SetActive(true);
        Invoke("DeactivePopup",4f);
    }

    void DeactivePopup(){
         popUp.SetActive(false);
    }
}
