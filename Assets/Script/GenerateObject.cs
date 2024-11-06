using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{  
    public GameObject prefabToSpawn;
    public GameObject[] objects;
    public GameObject spawnPosition;
    private GameObject[] obj = new GameObject[6];
    private GameObject[] spawnPoints = new GameObject[2];
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        //store container points to an array
        for (int count = 0; count < spawnPosition.transform.childCount - 1; count++)
        {
            spawnPoints[count] = spawnPosition.transform.GetChild(count + 1).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GenerateApple()
    {
        if (playerManager.playerMoney >= 180)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 0);
                playerManager.playerMoney -= 180;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }


    }

    public void GenerateBottledWater()
    {
        if (playerManager.playerMoney >= 40)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 1);
                playerManager.playerMoney -= 40;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }

    }

    public void GenerateCannedBeer()
        {
            if (playerManager.playerMoney >= 120)
            {
                //Check spawnposition and return position
                GameObject pos = CheckContainerPos();
                if (pos != null)
                {
                    GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                    crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    crate.transform.SetParent(pos.transform);
                    PutItemstoCrate(crate, 2);
                    playerManager.playerMoney -= 120;
                    playerManager.DisplayPlayerMoney();
            }
                else
                {
                    Debug.Log("Cannot Spawn anymore");
                }
            }

        }

    public void GenerateCherry()
    {
        if (playerManager.playerMoney >= 70)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 3);
                playerManager.playerMoney -= 70;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }

    }

    public void GenerateChewingGum()
    {
        if (playerManager.playerMoney >= 20)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 4);
                playerManager.playerMoney -= 20;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }

    }

    public void GenerateChips()
    {
        if (playerManager.playerMoney >= 200)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 5);
                playerManager.playerMoney -= 200;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }

    }

    public void GenerateCigarettes()
    {
        if (playerManager.playerMoney >= 250)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 6);
                playerManager.playerMoney -= 250;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }
    }

    public void GenerateCoffee()
    {
        if (playerManager.playerMoney >= 150)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 7);
                playerManager.playerMoney -= 150;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }
    }

    public void GenerateEnergyDrink()
    {
        if (playerManager.playerMoney >= 130)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 8);
                playerManager.playerMoney -= 130;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }
    }

    public void GenerateGuava()
    {
        if (playerManager.playerMoney >= 30)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 9);
                playerManager.playerMoney -= 30;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }
    }

    public void GenerateMilk()
    {
        if (playerManager.playerMoney >= 200)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 10);
                playerManager.playerMoney -= 200;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }
    }

    public void GenerateOrange()
    {
        if (playerManager.playerMoney >= 40)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 11);
                playerManager.playerMoney -= 40;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }
    }

    public void GenerateSandwich()
    {
        if (playerManager.playerMoney >= 200)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 12);
                playerManager.playerMoney -= 200;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }
    }

    public void GenerateSoftDrink()
    {
        if (playerManager.playerMoney >= 50)
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 13);
                playerManager.playerMoney -= 50;
                playerManager.DisplayPlayerMoney();
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }
        }
    }

    private void PutItemstoCrate(GameObject crate, int objectCount)
    {
        for (int x = 0; x < 6; x++)
        {
            obj[x] = Instantiate(objects[objectCount], crate.transform.GetComponent<CrateManager>().itemPos[x].transform.localPosition,
                Quaternion.identity);
            switch (x)
            {
                case 0:
                    obj[x].transform.SetParent(crate.transform.Find("ItemPos1"));
                    break;
                case 1:
                    obj[x].transform.SetParent(crate.transform.Find("ItemPos2"));
                    break;
                case 2:
                    obj[x].transform.SetParent(crate.transform.Find("ItemPos3"));
                    break;
                case 3:
                    obj[x].transform.SetParent(crate.transform.Find("ItemPos4"));
                    break;
                case 4:
                    obj[x].transform.SetParent(crate.transform.Find("ItemPos5"));
                    break;
                case 5:
                    obj[x].transform.SetParent(crate.transform.Find("ItemPos6"));
                    break;

            }

            obj[x].transform.localPosition = Vector3.zero;
            obj[x].GetComponent<ObjectGrabbable>().isInCrate = true;
            obj[x].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private GameObject CheckContainerPos()
    {
        foreach (GameObject obj in spawnPoints)
        {
            if (obj.transform.childCount == 0)
            {
                return obj;
            }
        }
        return null;
    }
}
