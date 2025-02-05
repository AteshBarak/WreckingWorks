using System.Collections.Generic;
using UnityEngine;

public class Film : MonoBehaviour
{
    public List<GameObject> emojis = new List<GameObject>();
    public Transform parent;
    public GameObject lockImage;

    public void ShowEmojis(int i)
    {
        lockImage.SetActive(false);
        GameObject _emoji = Instantiate(emojis[i], Vector2.zero, Quaternion.identity, parent);
        _emoji.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
}
