using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SellManager : MonoBehaviour
{
    public GameObject sellParent;
    public Rotator[] rotators;
    public ParticleSystem puffFX;

    public SellSound sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerCollect>().brokenList.Count > 0)
            {
                other.gameObject.GetComponent<PlayerCollect>().isExchanging = true;
                RotatorsActivity(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerCollect>().isExchanging = false;
            RotatorsActivity(false);
            sound.Pause();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerCollect>().brokenList.Count > 0)
            {
                other.gameObject.GetComponent<PlayerCollect>().Sell(GetComponent<SellManager>());
                RotatorsActivity(true);
                sound.Play();
                puffFX.Play();
            }
            else
            {
                RotatorsActivity(false);
                sound.Pause();
            }
        }
    }

    private void RotatorsActivity(bool _status)
    {
        for (int i = 0; i < rotators.Length; i++)
        {
            rotators[i].enabled = _status;
        }
    }
}
