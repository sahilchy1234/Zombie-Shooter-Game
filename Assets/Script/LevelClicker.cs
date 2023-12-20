using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelClicker : MonoBehaviour
{
    private Button _btn;
    public string levelName;
    public GameObject lockImg;
    // Start is called before the first frame update
    void Start()
    {
        _btn = gameObject.GetComponent<Button>();

        if (PlayerPrefs.GetInt(levelName) == 1)
        {
            _btn.interactable = true;
            lockImg.SetActive(false);
        }
        else
        {
            _btn.interactable = false;
            lockImg.SetActive(true);
        }

        Debug.Log(PlayerPrefs.GetInt(levelName));

    }

    public void LoadLevel (string sceneName) {
      SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
      
    }

}
