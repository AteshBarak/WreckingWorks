using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AlbumButton : MonoBehaviour
{
    public GameObject albumBG;

    public Button button;

    public void Open()
    {
        albumBG.transform.DOScale(Vector3.one, 0.35f);
        button.GetComponent<RectTransform>().DOAnchorPos3DX(-750, 0.35f);
    }

    public void Close()
    {
        button.GetComponent<RectTransform>().DOAnchorPos3DX(-155, 0.35f);
        albumBG.transform.DOScale(Vector3.zero, 0.35f);
    }
}
