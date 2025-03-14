using UnityEngine;
using TMPro;
public class Order : MonoBehaviour
{
    public bool orderSet = false;
    public int orderQuantity;
    public string orderType;
    public string orderDesc;
    public string[] types;
    public TMP_Text orderTextHelp;
    private void Update()
    {
        if (orderSet)
        {
            orderTextHelp.text = orderDesc;
        }
    }
}
