using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectBrokens : MonoBehaviour
{
    public PlayerCollect playerCollect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Broken"))
        {
            var brokenManager = other.gameObject.GetComponent<BrokenManager>();
            if (brokenManager != null && brokenManager.isBroke)
            {
                if (!playerCollect.isFull || playerCollect.isMaxCollect)
                {
                    if (playerCollect.brokenList.Count < playerCollect.maxCollect || playerCollect.isMaxCollect)
                    {
                        playerCollect.CollectBroken(other.gameObject);
                    }
                    else
                    {
                        playerCollect.isFull = true;
                        playerCollect.fullImage.transform.DOScale(Vector3.one * 0.5f, 0.5f);
                    }
                }
            }
        }
    }
}
