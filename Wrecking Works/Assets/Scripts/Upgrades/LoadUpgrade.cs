using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadUpgrade : MonoBehaviour
{
    public TextMeshProUGUI priceText;

    public TextMeshProUGUI levelText;

    public MoneyBankManager money;

    public PlayerCollect playerCollect;

    public int price;

    public int addPrice;

    private int levelCount = 1;

    public SpeedUpgrade speed;
    public IncomeUpgrade income;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxLoadPrice"))
        {
            price = PlayerPrefs.GetInt("MaxLoadPrice");
        }
        ShowMoneyText();
        CheckIfHaveMoney();
    }

    private void ShowMoneyText()
    {
        string m = price.ToString();
        string formatted = m;

        if (m.Length > 3)
        {
            int len = m.Length;
            int decimalPlace = len % 3 == 0 ? 3 : len % 3;
            formatted = m.Substring(0, decimalPlace) + "." + m.Substring(decimalPlace, 2) + "K";
        }

        priceText.text = formatted;

        if (PlayerPrefs.HasKey("LevelLoad"))
        {
            levelCount = PlayerPrefs.GetInt("LevelLoad");
            levelText.text = "Lvl." + levelCount;
        }
        else
        {
            levelText.text = "Lvl." + levelCount;
            PlayerPrefs.SetInt("LevelLoad", levelCount);
        }
    }

    public void CheckIfHaveMoney()
    {
        if (money.CheckMoney(price))
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void BuyButton()
    {
        if (price > 0)
        {
            if (money.CheckMoney(price))
            {
                money.Pay(price);
                price += addPrice;
                PlayerPrefs.SetInt("MaxLoadPrice", price);
                levelCount += 1;
                PlayerPrefs.SetInt("LevelLoad", levelCount);
                playerCollect.ChangeMaxCollect();
                price = 0;
                ShowMoneyText();
            }
            else
            {
                ShowMoneyText();
            }
        }
        else
        {
            ShowMoneyText();
        }

        ResetButton();
    }

    private void ResetButton()
    {
        if (PlayerPrefs.HasKey("MaxLoadPrice"))
        {
            price = PlayerPrefs.GetInt("MaxLoadPrice");
            ShowMoneyText();
        }

        CheckIfHaveMoney();
        speed.CheckIfHaveMoney();
        income.CheckIfHaveMoney();
    }
}