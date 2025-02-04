using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrokenParent : MonoBehaviour
{
    public List<GameObject> brokens = new List<GameObject>();

    //public Image bar;
    //public Image star;

    private float allBrokens = 0;
    private float addBar = 0;

    //public StopAllForButton stopAll;

    private void Awake()
    {
        SetBroken(brokens.Count);
    }

    public void SetBroken(int i)
    {
        allBrokens += (float)i;
        SetBarFillCount();
    }

    public void SetBarFillCount()
    {
        addBar = 1.0f / allBrokens;
    }

    public void AddToBar()
    {
        //bar.fillAmount += addBar;
    }

    public void DestroyCount(GameObject _object)
    {
        _object.GetComponent<BrokenManager>().Destroyed();
        brokens.Remove(_object);
        Destroy(_object);
        AddToBar();
        //if (bar.fillAmount > 0.9f)
        //{
        //    //stopAll.Final();
        //    star.enabled = true;
        //}
    }
}
