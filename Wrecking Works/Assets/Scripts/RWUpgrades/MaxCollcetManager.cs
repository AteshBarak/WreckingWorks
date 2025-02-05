using UnityEngine;
using UnityEngine.UI;

public class MaxCollcetManager : MonoBehaviour
{
    public PlayerCollect playerCollect;

    public string id_forThis;

    private void Start()
    {
        if (PlayerPrefs.HasKey("FakeLevel") && PlayerPrefs.HasKey(id_forThis))
        {
            if (PlayerPrefs.GetInt(id_forThis) > PlayerPrefs.GetInt("FakeLevel"))
            {
                playerCollect.MaximumCollect();
                GetComponent<Button>().interactable = false;
            }
        }
    }

    public void Get()
    {
        AfterAD();
    }

    public void AfterAD()
    {
        PlayerPrefs.SetInt(id_forThis, (PlayerPrefs.GetInt("FakeLevel", 1) + 2));
        playerCollect.MaximumCollect();
        GetComponent<Button>().interactable = false;
    }
}
