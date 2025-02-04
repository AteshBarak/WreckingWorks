using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SellManager : MonoBehaviour
{
    public GameObject sellParent;

    public SellSound sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerCollect>().brokenList.Count > 0)
            {
                other.gameObject.GetComponent<PlayerCollect>().isExchanging = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerCollect>().isExchanging = false;
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
                sound.Play();
            }
            else
            {
                sound.Pause();
            }
        }
    }
}
