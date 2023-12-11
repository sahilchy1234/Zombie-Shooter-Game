using UnityEngine;

public class ZombieAudioController : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component

    public AudioClip[] footstepSound; // Assign your footstep sound in the Unity editor
    public AudioClip[] attackSound; // Assign your attack sound in the Unity editor

    public AudioClip[] hurtSound;

    void Start()
    {
        // Get the AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Ensure that the AudioSource is not null
        if (audioSource == null)
        {
            // If AudioSource is not found, add it to the GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayFootstep()
    {
        // Check if the footstep sound is assigned
        if (footstepSound != null)
        {
            // Play the footstep sound
            audioSource.PlayOneShot(footstepSound[Random.Range(0,footstepSound.Length)]);
        }
        else
        {
            Debug.LogError("Footstep sound is not assigned.");
        }
    }

    public void PlaySoundOrDamageEvent()
    {
        // Check if the attack sound is assigned
        if (attackSound != null)
        {
            // Play the attack sound
            audioSource.PlayOneShot(attackSound[Random.Range(0,attackSound.Length)]);
        }
        else
        {
            Debug.LogError("Attack sound is not assigned.");
        }
    }

    public void PlayHurtSoundEffect()
    {
 if (hurtSound != null)
        {
            // Play the attack sound
            audioSource.PlayOneShot(hurtSound[Random.Range(0,hurtSound.Length)]);
        }
        else
        {
            Debug.LogError("Attack sound is not assigned.");
        }
    }
}
