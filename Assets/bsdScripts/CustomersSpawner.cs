using UnityEngine;

public class CustomersSpawner : MonoBehaviour
{
    public UIManager iManager;
    public GameObject customerPrefab;
    public GameObject specialCustomerPrefab;
    public Transform spawnPos;
    public int randCustomersCount;
    public bool newSpawn = true;
    public bool spawning = false;
    public bool onecSpec = true;
    public int customersSpawned = 0;
    public float timer;
    private void Update()
    {
        if (newSpawn)
        {
            if (iManager.isNight)
            {
                RandomizedQuantity();
                spawning = true;
                newSpawn = false;
                timer = 10f;
            }
        }
        if (spawning)
        {
            if (customersSpawned < randCustomersCount)
            {
                if(timer <= 0f)
                {
                    if (iManager.dayCounter == 0)
                    {
                        //normal
                        SpawnCustomer();
                        timer = 10f;
                        customersSpawned++;
                    }
                    if (iManager.dayCounter != 0)
                    {
                        //special
                        if (onecSpec)
                        {
                            SpawnCustomerS();
                            onecSpec = false;
                            customersSpawned++;
                            timer = 10f;
                        }
                        else
                        {
                            SpawnCustomer();
                            customersSpawned++;
                            timer = 10f;
                        }
                    }
                    //customersSpawned++;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
            else
            {
                spawning = false;
            }
        }
        if (GameObject.FindGameObjectsWithTag("Customer").Length == 0 && !spawning)
        {
            GetDay();
        }
    }
    public void GetDay()
    {
        newSpawn = true;
        iManager.isNight = false;
    }
    public void RandomizedQuantity()
    {
        randCustomersCount = Random.Range(5, 11);
    }
    public void SpawnCustomer()
    {
        Instantiate(customerPrefab, spawnPos.position,spawnPos.rotation);
        //customersSpawned++;
    }
    public void SpawnCustomerS()
    {
        Instantiate(specialCustomerPrefab, spawnPos.position, spawnPos.rotation);
        //customersSpawned++;
    }
}
