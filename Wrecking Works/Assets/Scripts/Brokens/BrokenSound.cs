using System.Collections;
using UnityEngine;

public class BrokenSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float soundDuration;
    private bool isPlaying = false;

    public VibrationManager vibration;

    public void PlayScrape()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlaySoundForDuration());
        }
        vibration.Vibrate();
    }

    private IEnumerator PlaySoundForDuration()
    {
        isPlaying = true;

        if (audioSource.isPlaying)
        {
            audioSource.time = audioSource.time;
        }
        else
        {
            audioSource.Play();
        }

        float elapsedTime = 0f;

        while (elapsedTime < soundDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        audioSource.Pause();
        isPlaying = false;
    }
}
