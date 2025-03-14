using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class playerInventory : MonoBehaviour
{
    public PickableObject[] inventory = new PickableObject[5];
    int maxIndex = 80;
    public Transform inn;
    public Transform outt;
    public GameObject podT;

    public void Update()
    {
        RaycastHit rh;
        if (Physics.Linecast(inn.position, outt.position, out rh))
        {
            podT.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                PickableObject obj = rh.collider.gameObject.GetComponent<PickableObject>();
                if(obj != null) pickup(obj);
            }
            
        }
        else {
            podT.SetActive(false);
        }
        


        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     PickableObject obj = GameObject.Find("dupa").GetComponent<PickableObject>();
        //     pickup(obj);
        // }
    }

    public void pickup(PickableObject obj)
    {
        maxIndex = 9999;
        
        for (int i = 0; i < inventory.Length; i++)
        {
            Debug.Log(i);
            if(inventory[i] == null) 
            {
                maxIndex = i;
                break;
            }
        }
        if(maxIndex < 5)
        {
            
            Debug.Log(maxIndex);
            inventory[maxIndex] = obj;
            
            obj.transform.parent = transform;
            obj.transform.position = new Vector3(0, 0, 0);
            obj.gameObject.SetActive(false);
            obj.transform.position = new Vector3(0, 0, 0);
            refreshInv();
        }
        else {
            Debug.Log("Inventory full.");
        }
        
    }


    private void refreshInv()
    {
        string s = "";
        foreach (PickableObject item in inventory)
        {
            if(item != null) s += item.objectName + " ";
            
        }
        Debug.Log(s);
        
    }




    public void drop()
    {

    }
}
