using UnityEngine;
using UnityEngine.UI;

public class MaxSpeedManager : MonoBehaviour
{
    public PlayerMove playerMove;

    public string id_forThis;

    private void Start()
    {
        if (PlayerPrefs.HasKey("FakeLevel") && PlayerPrefs.HasKey(id_forThis))
        {
            if (PlayerPrefs.GetInt(id_forThis) > PlayerPrefs.GetInt("FakeLevel"))
            {
                playerMove.isMaxSpeed = true;
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
        playerMove.isMaxSpeed = true;
        GetComponent<Button>().interactable = false;
    }
}
