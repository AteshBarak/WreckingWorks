using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyBankManager : MonoBehaviour
{
    [Header("Money info text")]
    public TextMeshProUGUI moneyText;

    public int money = 0;

    private void Awake()
    {
        CheckMoneyStart();
    }

    private void ShowMoney()
    {
        string m = money.ToString();
        switch (m.Length)
        {
            case 1:
                moneyText.text = money.ToString();
                break;
            case 2:
                moneyText.text = money.ToString();
                break;
            case 3:
                moneyText.text = money.ToString();
                break;
            case 4:
                moneyText.text = m.Substring(0, 1) + "." + m.Substring(1, 2) + "K";
                break;
            case 5:
                moneyText.text = m.Substring(0, 2) + "." + m.Substring(2, 2) + "K";
                break;
            case 6:
                moneyText.text = m.Substring(0,3) + "." + m.Substring(3,2) + "K";
                break;
            default:
                moneyText.text = money.ToString();
                break;
        }
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
