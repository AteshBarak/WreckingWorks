using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public List<GameObject> brokenList = new List<GameObject>();
    public GameObject brokenParent;

    private float yPos = 0;
    public float addYPos;

    public int maxCollect;
    public GameObject fullImage;
    public bool isFull = false;
    public bool isExchanging = false;

    public MoneyBankManager money;
    public bool incomeBoost = false;
    public PlayerSound sound;

    private BrokenParent brokenParentManager;

    public bool isMaxCollect = false;

    private void Start()
    {
        brokenParentManager = FindAnyObjectByType<BrokenParent>();

        if (PlayerPrefs.HasKey("MaxCollect"))
        {
            maxCollect = PlayerPrefs.GetInt("MaxCollect");
        }
    }

    public void ChangeMaxCollect()
    {
        if (PlayerPrefs.HasKey("LevelLoad"))
        {
            if (PlayerPrefs.GetInt("LevelLoad") < 3)
            {
                maxCollect += 100;
            }
            else if (PlayerPrefs.GetInt("LevelLoad") < 6)
            {
                maxCollect += 75;
            }
            else if (PlayerPrefs.GetInt("LevelLoad") < 10)
            {
                maxCollect += 50;
            }
            else
            {
                maxCollect += 40;
            }
        }

        if(maxCollect > 4000)
        {
            maxCollect = 4000;
        }

        PlayerPrefs.SetInt("MaxCollect", maxCollect);

        isFull = false;
        fullImage.GetComponent<Image>().enabled = false;
    }

    public void CollectBroken(GameObject _broken)
    {
        if (_broken != null && (!isFull || isMaxCollect))
        {
            brokenList.Add(_broken);
            _broken.GetComponent<Collider>().enabled = false;
            _broken.transform.parent = brokenParent.transform;
            Vector3 _newPos = Vector3.zero;
            _newPos.y = yPos + (addYPos * brokenList.Count);
            _broken.transform.DOLocalJump(_newPos, 1.5f, 1, 0.5f);
            sound.PlayCollect();

            if (brokenList.Count >= maxCollect && !isFull && !isMaxCollect)
            {
                isFull = true;
                fullImage.GetComponent<Image>().enabled = true;
            }
        }
    }

    public void Sell(SellManager _sellManager)
    {
        if (brokenList.Count > 0)
        {
            StartCoroutine(ExchangeToSell(_sellManager));
        }
    }

    private IEnumerator ExchangeToSell(SellManager _sellManager)
    {
        int totalBrokenCount = brokenList.Count;

        int step = 1;
        if (totalBrokenCount > 100)
        {
            step = 10;
        }
        else if (totalBrokenCount > 50)
        {
            step = 5;
        }

        while (brokenList.Count > 0 && isExchanging)
        {
            int batchCount = Mathf.Min(step, brokenList.Count);

            for (int i = 0; i < batchCount; i++)
            {
                if (brokenList.Count == 0 || !isExchanging)
                    break;

                GameObject _broken = brokenList[brokenList.Count - 1];
                if(_broken != null)
                {
                    _broken.transform.parent = _sellManager.sellParent.transform;
                    brokenList.Remove(_broken);
                    if (incomeBoost)
                    {
                        money.AddMoney(3);
                    }
                    else
                    {
                        money.AddMoney(1);
                    }
                    _broken.transform.DOLocalJump(Vector3.zero, 1f, 1, 0.35f).onComplete += () =>
                    {
                        brokenParentManager.DestroyCount(_broken);
                    };
                    isFull = false;
                    fullImage.GetComponent<Image>().enabled = false;
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    brokenList.RemoveAt(brokenList.Count - 1);
                    continue;
                }
                
            }
            yield return new WaitForSeconds(0.5f);
        }

        isExchanging = false;
    }

    public void MaximumCollect()
    {
        isMaxCollect = true;
        isFull = false;
        fullImage.GetComponent<Image>().enabled = false;
    }
}
