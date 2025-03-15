using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class playerInventory : MonoBehaviour
{
    public PickableObject[] inventory = new PickableObject[5];

    public PickableObject selectedItem = null;
    int maxIndex = 80;
    public Transform inn;
    public Transform outt;
    public GameObject podT;
    public GameObject water;
    public GameObject zboze;

    public GameObject alerttext;

    public void Update()
    {
        RaycastHit rh;
        if (Physics.Linecast(inn.position, outt.position, out rh))
        {
            
            
            PickableObject obj = rh.collider.gameObject.GetComponent<PickableObject>();
            if(obj != null)
            {

            
                podT.GetComponentInChildren<TMP_Text>().text = "E  " + obj.text;
                if (obj.text != "")podT.SetActive(true);
               
                if(Input.GetKeyDown(KeyCode.E))
                {   
                    if(obj.text == "Podnieś") pickup(obj);
                    else if (obj.text == "Nalej") Nalej(obj);
                    else if (obj.text == "Otwórz") Otworz(obj);
                    else if (obj.text == "Zamknij") Zamknij(obj);
                    else if (obj.text == "Dosyp") Dosyp(obj);
                    
                }
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

    public void Otworz(PickableObject obj)
    {
        obj.gameObject.GetComponentInChildren<Animator>().SetTrigger("open");
        obj.text = "Nalej";
    }

    public void Nalej(PickableObject obj)
    {
        Debug.Log("Nalano wode");
        water.SetActive(true);
        obj.text = "Dosyp";
    }

    public void Dosyp(PickableObject obj)
    {
        if(selectedItem != null)
        {
            if(selectedItem.objectName == "Zboże") zboze.SetActive(true);
            else alert("Musisz trzymać zboże.");
            
        }
        else alert("Musisz trzymać zboże.");

    }

    public void Zamknij(PickableObject obj)
    {
        obj.gameObject.GetComponentInChildren<Animator>().SetTrigger("close");
        obj.text = "Otwórz";
        water.SetActive(false);
    }

    public void alert(string text)
    {
        StartCoroutine(AlertCoroutine(text));
    }

    public IEnumerator AlertCoroutine(string text)
    {
        alerttext.GetComponent<TMP_Text>().text = text;
        alerttext.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        alerttext.SetActive(false);

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
