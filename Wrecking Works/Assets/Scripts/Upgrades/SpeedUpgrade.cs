using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedUpgrade : MonoBehaviour
{
    public TextMeshProUGUI priceText;

    public TextMeshProUGUI levelText;

    public MoneyBankManager money;

    public PlayerMove playerMove;

    public int price;

    public int addPrice;

    private int levelCount = 1;

    public LoadUpgrade load;
    public IncomeUpgrade income;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MaxSpeedPrice"))
        {
            price = PlayerPrefs.GetInt("MaxSpeedPrice");
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

        if (PlayerPrefs.HasKey("LevelSpeed"))
        {
            levelCount = PlayerPrefs.GetInt("LevelSpeed");
            levelText.text = "Lvl." + levelCount;
        }
        else
        {
            levelText.text = "Lvl." + levelCount;
            PlayerPrefs.SetInt("LevelSpeed", levelCount);
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
                PlayerPrefs.SetInt("MaxSpeedPrice", price);
                levelCount += 1;
                PlayerPrefs.SetInt("LevelSpeed", levelCount);
                playerMove.ChangeMaxSpeed();
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
        if (PlayerPrefs.HasKey("MaxSpeedPrice"))
        {
            price = PlayerPrefs.GetInt("MaxSpeedPrice");
            ShowMoneyText();
        }

        CheckIfHaveMoney();
        load.CheckIfHaveMoney();
        income.CheckIfHaveMoney();
    }
}