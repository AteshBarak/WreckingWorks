using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumManager : MonoBehaviour
{
    private List<Film> films = new List<Film>();

    private int emojisIndex = 0;

    public ScrollRect scrollRect;
    public GridLayoutGroup gridLayoutGroup;
    public RectTransform contentPanel;

    private void Awake()
    {
        PlayerPrefs.SetInt("EmojisIndex", 45);

        for (int i = 0; i < transform.childCount; i++)
        {
            films.Add(transform.GetChild(i).gameObject.GetComponent<Film>());
        }

        if(PlayerPrefs.HasKey("EmojisIndex")) 
        {
            emojisIndex = PlayerPrefs.GetInt("EmojisIndex");
        }

        for(int i = 0; i < emojisIndex; i++)
        {
            films[i].ShowEmojis(i);
        }

        scrollRect.verticalNormalizedPosition = 1.0f;
    }

    private void Start()
    {
        float itemHeight = gridLayoutGroup.cellSize.y + gridLayoutGroup.spacing.y;
        float targetY = (emojisIndex - 1) * itemHeight;
        float normalizedPosition = Mathf.Clamp01(1 - (targetY / contentPanel.sizeDelta.y));
        scrollRect.verticalNormalizedPosition = normalizedPosition;
    }
}
