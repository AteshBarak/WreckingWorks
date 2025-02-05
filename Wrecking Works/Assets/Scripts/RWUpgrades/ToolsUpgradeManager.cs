using UnityEngine;
using UnityEngine.UI;

public class ToolsUpgradeManager : MonoBehaviour
{
    public ToolsSelect toolsSelect;
    public Text levelInfo;
    public string id_forThis;

    private void Start()
    {
        if (PlayerPrefs.HasKey("FakeLevel") && PlayerPrefs.HasKey(id_forThis))
        {
            if(PlayerPrefs.GetInt(id_forThis) > PlayerPrefs.GetInt("FakeLevel"))
            {
                levelInfo.text = "Reach\nLevel " + PlayerPrefs.GetInt(id_forThis);
                GetComponent<Button>().interactable = false;
            }
        }

        if (!toolsSelect.CheckTool())
        {
            if (PlayerPrefs.GetInt("FakeLevel", 1) < 80)
            {
                levelInfo.text = "Reach\nLevel 100";
            }
            else if (PlayerPrefs.GetInt("FakeLevel", 1) < 150)
            {
                levelInfo.text = "Reach\nLevel 200";
            }
            else
            {
                levelInfo.text = "Reach\nLevel 1000";
            }
        }
    }

    public void Get()
    {
        AfterAD();
    }

    public void AfterAD()
    {
        PlayerPrefs.SetInt(id_forThis, (PlayerPrefs.GetInt("FakeLevel",1) + 2));
        toolsSelect.ChangeTool();
        GetComponent<Button>().interactable = false;

        if (!toolsSelect.CheckTool())
        {
            if (PlayerPrefs.GetInt("FakeLevel", 1) < 80)
            {
                levelInfo.text = "Reach\nLevel 100";
            }
            else if (PlayerPrefs.GetInt("FakeLevel", 1) < 150)
            {
                levelInfo.text = "Reach\nLevel 200";
            }
            else
            {
                levelInfo.text = "Reach\nLevel 1000";
            }
        }
        else
        {
            levelInfo.text = "Reach\nLevel " + PlayerPrefs.GetInt(id_forThis);
        }
    }
}
