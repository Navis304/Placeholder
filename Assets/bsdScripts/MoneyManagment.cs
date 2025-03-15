using UnityEngine;
using TMPro;
public class MoneyManagment : MonoBehaviour
{
    public float money = 50f;
    public TMP_Text moneyText;
    private void Awake()
    {
        SetMoneyText();
    }
    public void SetMoneyText()
    {
        moneyText.text = money.ToString("0.00");
    }
    public void Spend(float moneyS)
    {
        money -= moneyS;
        SetMoneyText();
    }
    public void Gain(float moneyG)
    {
        money += moneyG;
        SetMoneyText();
    }

}
