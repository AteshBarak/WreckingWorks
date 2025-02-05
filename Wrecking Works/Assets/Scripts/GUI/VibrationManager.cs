using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrationManager : MonoBehaviour
{
    private float waitTime = 0.17f;

    private bool isOff = false;

    public Image icon;

    private void Awake()
    {
        if(PlayerPrefs.HasKey("VibrationStatus"))
        {
            if(PlayerPrefs.GetString("VibrationStatus") == "Off")
            {
                icon.color = Color.black;
                isOff = true;
            }
            else
            {
                icon.color = Color.white;
                isOff = false;
            }
        }
    }

    public void Vibrate()
    {
        if (isOff) return;

        if (waitTime > 0.17f)
        {
            waitTime = 0;
            Vibration.VibrationFunc();
        }
    }

    private void Update()
    {
        waitTime += Time.deltaTime;
    }

    public void ChangeStatus()
    {
        isOff = !isOff;
        if (isOff == false)
        {
            icon.color = Color.white;
            PlayerPrefs.SetString("VibrationStatus", "On");
        }
        else
        {
            icon.color = Color.black;
            PlayerPrefs.SetString("VibrationStatus", "Off");
        }
    }
}
