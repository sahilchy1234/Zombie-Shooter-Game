using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    public float delay = 0.1f; // Delay between each character
    public string fullText; // The complete text to be displayed
    private string currentText = ""; // The text being displayed progressively
    private TMP_Text textComponent; // Reference to the TextMeshPro component
    public GameObject audioSource;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        audioSource.SetActive(true);

        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        audioSource.SetActive(false);
    }

     void OnDisable() {
        audioSource.SetActive(false);
    }
}
