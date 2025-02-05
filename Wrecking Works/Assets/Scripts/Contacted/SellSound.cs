using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellSound : MonoBehaviour
{
    public AudioSource audioSource;
    private bool isPlay = false;

    public VibrationManager vibration;

    public void Play()
    {
        if (!isPlay)
        {
            isPlay = true;
            audioSource.Play();
        }
        vibration.Vibrate();
    }

    public void Pause()
    {
        if (isPlay)
        {
            isPlay = false;
            audioSource.Pause();
        }
    }
}
