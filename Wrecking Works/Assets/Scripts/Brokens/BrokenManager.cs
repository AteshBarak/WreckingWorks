using UnityEngine;
using DG.Tweening;

public class BrokenManager : MonoBehaviour
{
    private string _name;

    public bool isBroke = false;

    public BrokenParent brokenParent;

    public BrokenSound sound;

    private void Awake()
    {
        string fakeName = _name;
        string fakeName2 = _name;
        _name += "_" + PlayerPrefs.GetInt("FakeLevel", 1) + "_";
        fakeName += "_" + (PlayerPrefs.GetInt("FakeLevel", 1) - 1) + "_";
        fakeName2 += "_" + (PlayerPrefs.GetInt("FakeLevel", 1) - 2) + "_";
        _name += transform.GetSiblingIndex().ToString();
        fakeName += transform.GetSiblingIndex().ToString();
        fakeName2 += transform.GetSiblingIndex().ToString();

        if (PlayerPrefs.HasKey(fakeName))
        {
            PlayerPrefs.DeleteKey(fakeName);
        }

        if (PlayerPrefs.HasKey(fakeName2))
        {
            PlayerPrefs.DeleteKey(fakeName2);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey(_name))
        {
            brokenParent.DestroyCount(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Tools"))
        {
            if(!isBroke)
            {
                ExplosionFX();
            }
        }
    }

    public void ExplosionFX()
    {
        if (isBroke) return;

        sound.PlayScrape();
        Vector3 _newPos = transform.localPosition;
        _newPos += new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f));
        _newPos.y = -1;
        transform.DOLocalRotate(new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90)), 0.75f);
        transform.DOLocalJump(_newPos, 1, 1, 0.75f).SetEase(Ease.InFlash).onComplete += () =>
        {
            isBroke = true;
        };
    }

    public void Destroyed()
    {
        PlayerPrefs.SetString(_name, "Destroy");
    }
}
