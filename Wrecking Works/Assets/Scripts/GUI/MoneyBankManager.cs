using UnityEngine;
using TMPro;

public class MoneyBankManager : MonoBehaviour
{
    [Header("Money info text")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyText2;

    public int money = 0;

    private void Awake()
    {
        CheckMoneyStart();
    }

    private void ShowMoney()
    {
        string m = money.ToString();
        string formatted = m;

        if (m.Length > 3)
        {
            int len = m.Length;
            int decimalPlace = len % 3 == 0 ? 3 : len % 3;
            formatted = m.Substring(0, decimalPlace) + "." + m.Substring(decimalPlace, 2) + "K";
        }

        moneyText.text = formatted;
        moneyText2.text = formatted;
    }

    private void CheckMoneyStart()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else
        {
            PlayerPrefs.SetInt("Money", money);
        }
        ShowMoney();
    }

    public bool CheckMoney(int _price)
    {
        if (_price > money)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Pay(int _price)
    {
        money -= _price;
        PlayerPrefs.SetInt("Money", money);
        ShowMoney();
    }

    public void AddMoney(int _comeMoney)
    {
        money += _comeMoney;
        PlayerPrefs.SetInt("Money", money);
        ShowMoney();
    }
}
