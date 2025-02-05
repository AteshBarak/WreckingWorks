using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RepairButton : MonoBehaviour
{
    public GameObject reapirBG;

    public Button button;

    public LoadUpgrade load;
    public SpeedUpgrade speed;
    public IncomeUpgrade income;

    public void Open()
    {
        reapirBG.transform.DOScale(Vector3.one, 0.35f);
        button.GetComponent<RectTransform>().DOAnchorPos3DX(750, 0.35f);
        load.CheckIfHaveMoney();
        speed.CheckIfHaveMoney();
        income.CheckIfHaveMoney();
    }

    public void Close()
    {
        button.GetComponent<RectTransform>().DOAnchorPos3DX(155, 0.35f);
        reapirBG.transform.DOScale(Vector3.zero, 0.35f);
    }
}
