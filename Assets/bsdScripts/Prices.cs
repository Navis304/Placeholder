using UnityEngine;

public class Prices : MonoBehaviour
{
    public MoneyManagment mm;

    public float price(string item)
    {
        switch(item)
        {
            case "wheat":
                return 3.30f;
            case "hop":
                return 3.50f; 
            default:
                return 999999f;
        }
        
    }

    public void buy(PickableObject obj, playerInventory script)
    {
        if(mm.money >= price(obj.buyable))
        {
            mm.Spend(price(obj.buyable));
            script.pickup(obj);

        }
        else script.alert("Nie stać cię na to.");
        
    }
    
}
