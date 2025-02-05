using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ToolsSelect : MonoBehaviour
{
    public GameObject[] tools;
    public int toolIndex = 0;

    private void Awake()
    {
        toolIndex = PlayerPrefs.GetInt("ToolIndex", 0);
        tools[toolIndex].SetActive(true);
    }

    public void ChangeTool()
    {
        toolIndex++;
        PlayerPrefs.SetInt("ToolIndex", toolIndex);
        for(int i = 0; i < tools.Length; i++)
        {
            tools[i].SetActive(false);
        }
        Vector3 _scale = tools[toolIndex].transform.localScale;
        tools[toolIndex].transform.localScale = Vector3.zero;
        tools[toolIndex].SetActive(true);
        tools[toolIndex].transform.DOScale(_scale, 0.5f);
    }

    public bool CheckTool()
    {
        if(toolIndex < tools.Length - 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MaxTool()
    {
        toolIndex = tools.Length - 1;
        PlayerPrefs.SetInt("ToolIndex", toolIndex);
        for (int i = 0; i < tools.Length; i++)
        {
            tools[i].SetActive(false);
        }
        tools[toolIndex].SetActive(true);
    }
}
