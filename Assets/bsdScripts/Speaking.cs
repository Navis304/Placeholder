using UnityEngine;
using System.Collections;
using TMPro;
public class Speaking : MonoBehaviour
{
    [SerializeField] private string whatKindOfDialog;
    [SerializeField] private UIManager uIManager;
    [SerializeField] public Order orderScript;
    [SerializeField] private GameObject blob;
    
    private void Start()
    {
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        orderScript = GameObject.Find("OrderManager").GetComponent<Order>();
        // orderScript = GameObject.Find("Order").GetComponent<Order>();
        //SpeakAction();
    }
    public void SpeakAction()
    {
        orderScript.orderQuantity = Random.Range(1,4);
        orderScript.orderType = orderScript.types[Random.Range(0, 3)];
        if(whatKindOfDialog == "normal")
        {
            if(orderScript.orderQuantity > 1)
            {
                uIManager.TextWriter($"{uIManager.npcNormalTalk[0]} {orderScript.orderQuantity} {orderScript.orderType} {uIManager.npcNormalTalk[1]}a.");
                orderScript.orderDesc = orderScript.orderQuantity + " " + uIManager.npcNormalTalk[1] + "a " + orderScript.orderType;
            }
            else
            {
                uIManager.TextWriter($"{uIManager.npcNormalTalk[0]} {orderScript.orderQuantity} {orderScript.orderType} {uIManager.npcNormalTalk[1]}o.");
                orderScript.orderDesc = orderScript.orderQuantity + " " + uIManager.npcNormalTalk[1] + "o " + orderScript.orderType;
            }
            orderScript.orderSet = true;
        }
        else if (whatKindOfDialog == "special")
        {
            if (orderScript.orderQuantity > 1)
            {
                uIManager.TextWriter($"{uIManager.specialNpcTalk[0]} {orderScript.orderQuantity} {orderScript.orderType} {uIManager.specialNpcTalk[1]}a.");
                orderScript.orderDesc = orderScript.orderQuantity + " " + uIManager.specialNpcTalk[1] + "a " + orderScript.orderType;
            }
            else
            {
                uIManager.TextWriter($"{uIManager.specialNpcTalk[0]} {orderScript.orderQuantity} {orderScript.orderType} {uIManager.specialNpcTalk[1]}a.");
                orderScript.orderDesc = orderScript.orderQuantity + " " + uIManager.specialNpcTalk[1] + "o " + orderScript.orderType;
            }
            orderScript.orderSet = true;
        }
       
    }
    public void GetOrder()
    {
        //funkcja do odbierania zam�wien
    }
    
}
