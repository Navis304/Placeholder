using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class playerInventory : MonoBehaviour
{
    public PickableObject[] inventory = new PickableObject[5];

    public PickableObject selectedItem = null;
    public int sid = 0;
    int maxIndex = 80;
    public Transform inn;
    public Transform outt;
    public GameObject podT;
    public GameObject water;
    public GameObject zboze;
    public Transform inventoryUI;
    public GameObject alerttext;
    public Sprite nothing;
    public GameObject[] children;

    public bool inventoryFull = false;

    public Prices shop;


    // public void Start () {
    //     children = inventoryUI.GetComponentsInChildren<Image>();
    // }

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
                    else if (obj.text == "Kup") Kup(obj);
                    
                }
            }
               
        }
        else {
            podT.SetActive(false);
        }
        



        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            chooseSlot(0);
            
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            chooseSlot(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            chooseSlot(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            chooseSlot(3);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            chooseSlot(4);
        }

       
    }

    public void chooseSlot(int i)
    {
        selectedItem = inventory[i];
        sid = i;
        foreach (GameObject item in children)
        {
            item.GetComponent<Outline>().enabled = false;
            
        }
        // Debug.Log(i);
        children[i].GetComponent<Outline>().enabled = true;
    }

    public void Otworz(PickableObject obj)
    {
        obj.gameObject.GetComponentInChildren<Animator>().SetTrigger("open");
        obj.text = "Nalej";
    }

    public void Nalej(PickableObject obj)
    {
        if(selectedItem != null)
        {
            if(selectedItem.objectName == "Wiadro")
            {
                Debug.Log("Nalano wode");
                water.SetActive(true);
                obj.text = "Dosyp";
                DeleteItem(sid);
            }
            else alert("Musisz trzymać wiadro z wodą.");
        }
        else alert("Musisz trzymać wiadro z wodą.");
        
    }

    public void Kup(PickableObject obj)
    {
        if(!inventoryFull) shop.buy(obj, this);
        else alert("Nie ma miejsca w ekwipunku.");
    }

    public void Dosyp(PickableObject obj)
    {
        if(selectedItem != null)
        {
            if(selectedItem.objectName == "Jęczmień") {
                water.SetActive(false);
                zboze.SetActive(true);
                obj.text = "Zabierz do suszenia";
            }
            else alert("Musisz trzymać jakiś rodzaj zboża.");
            
        }
        else alert("Musisz trzymać zboże.");

    }

    public void Zamknij(PickableObject obj)
    {
        obj.gameObject.GetComponentInChildren<Animator>().SetTrigger("close");
        obj.text = "Otwórz";
        water.SetActive(false);
    }

    public void DeleteItem(int i)
    {
        inventory[i] = null;
        children[i].transform.GetComponentsInChildren<Image>()[1].sprite = nothing;
        inventoryFull = false;
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
        selectedItem = inventory[sid];
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
            children[maxIndex].transform.GetComponentsInChildren<Image>()[1].sprite = obj.icon;
            obj.transform.parent = transform;
            obj.transform.position = new Vector3(0, 0, 0);
            obj.gameObject.SetActive(false);
            obj.transform.position = new Vector3(0, 0, 0);
            refreshInv();
        }
        else {
            inventoryFull = true;
            alert("Nie ma miejsca w ekwipunku.");
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
