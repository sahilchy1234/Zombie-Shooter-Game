using UnityEngine;

public class GraphicsSettingsManager : MonoBehaviour
{
    private const string GraphicsQualityKey = "DropdownDropdown";

    // Possible graphics quality levels
    public enum GraphicsQuality
    {
        Low,
        Good,
        High
    }



 void Update()
{
    ApplyGraphicsSettings();
}
    // Set the graphics quality level and save it to PlayerPrefs
    public void SetGraphicsQuality(GraphicsQuality quality)
    {
        PlayerPrefs.SetInt(GraphicsQualityKey, (int)quality);
        ApplyGraphicsSettings();
    }

    // Get the current graphics quality level
    public GraphicsQuality GetGraphicsQuality()
    {
        return (GraphicsQuality)PlayerPrefs.GetInt(GraphicsQualityKey, (int)GraphicsQuality.Good);
    }

    // Apply the graphics settings based on the current quality level
    private void ApplyGraphicsSettings()
    {
        GraphicsQuality currentQuality = GetGraphicsQuality();

        switch (currentQuality)
        {
            case GraphicsQuality.Low:
                QualitySettings.SetQualityLevel(2); // Adjust this based on your quality settings
                break;

            case GraphicsQuality.Good:
                QualitySettings.SetQualityLevel(1); // Adjust this based on your quality settings
                break;

            case GraphicsQuality.High:
                QualitySettings.SetQualityLevel(0); // Adjust this based on your quality settings
                break;

            default:
                Debug.LogWarning("Unknown graphics quality level");
                break;
        }
    }
}
