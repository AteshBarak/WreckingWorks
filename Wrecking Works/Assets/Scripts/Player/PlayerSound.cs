using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource audioSource;
    public float soundDuration;
    private bool isPlaying = false;

    public AudioClip collectSFX;
    public AudioClip upgradeSFX;

    public VibrationManager vibration;

    public void PlayCollect()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlaySoundForDuration(collectSFX));
        }
        vibration.Vibrate();
    }

    public void PlayUpgrade()
    {
        vibration.Vibrate();
        audioSource.PlayOneShot(upgradeSFX);
    }

    private IEnumerator PlaySoundForDuration(AudioClip _sfx)
    {
        isPlaying = true;

        if (audioSource.isPlaying)
        {
            audioSource.time = audioSource.time;
        }
        else
        {
            audioSource.PlayOneShot(_sfx);
        }

        float elapsedTime = 0f;

        while (elapsedTime < soundDuration)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        isPlaying = false;
    }
}
