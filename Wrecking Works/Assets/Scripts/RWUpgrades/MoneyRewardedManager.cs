using UnityEngine;
using UnityEngine.UI;

public class MoneyRewardedManager : MonoBehaviour
{
    public MoneyBankManager moneyBankManager;
    public LoadUpgrade load;
    public SpeedUpgrade speed;
    public IncomeUpgrade income;

    public string id_forThis;

    private int moneyCount = 0;
    public Text moneyText;

    private void Start()
    {
        if (PlayerPrefs.HasKey(id_forThis))
        {
            if(PlayerPrefs.GetInt(id_forThis) >= PlayerPrefs.GetInt("FakeLevel", 1))
            {
                GetComponent<Button>().interactable = false;
                moneyText.fontSize = 115;
                moneyText.text = "Reach\nLevel" + (PlayerPrefs.GetInt(id_forThis) + 1);
            }
            else
            {
                if (PlayerPrefs.GetInt("FakeLevel", 1) <= 3)
                {
                    moneyCount += (PlayerPrefs.GetInt("FakeLevel", 1) * 500);
                }
                else
                {
                    moneyCount += (PlayerPrefs.GetInt("FakeLevel", 1) * 400);
                }
                moneyText.fontSize = 145;
                moneyText.text = "$" + moneyCount;
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("FakeLevel", 1) <= 3)
            {
                moneyCount += (PlayerPrefs.GetInt("FakeLevel", 1) * 500);
            }
            else
            {
                moneyCount += (PlayerPrefs.GetInt("FakeLevel", 1) * 400);
            }
            moneyText.fontSize = 145;
            moneyText.text = "$" + moneyCount;
        }
        
    }

    public void Get()
    {
        AfterAD();
    }

    public void AfterAD()
    {
        moneyBankManager.AddMoney(moneyCount);
        PlayerPrefs.SetInt(id_forThis, PlayerPrefs.GetInt("FakeLevel", 1));
        GetComponent<Button>().interactable = false;
        moneyText.fontSize = 115;
        moneyText.text = "Reach\nLevel" + (PlayerPrefs.GetInt(id_forThis) + 1);
        load.CheckIfHaveMoney();
        speed.CheckIfHaveMoney();
        income.CheckIfHaveMoney();
    }
}
