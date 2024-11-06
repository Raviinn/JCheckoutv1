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
    // Start is called before the first frame update
    void Start()
    {
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
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 0);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateBottledWater()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 1);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateCannedBeer()
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate, 2);
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }


        }

    public void GenerateCherry()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 3);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateChewingGum()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 4);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateChips()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 5);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateCigarettes()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 6);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateCoffee()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 7);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateEnergyDrink()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 8);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateGuava()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 9);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }


    }

    public void GenerateMilk()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 11);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }
    }

    public void GenerateOrange()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 12);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }
    }

    public void GenerateSandwich()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 13);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
        }
    }

    public void GenerateSoftDrink()
    {
        //Check spawnposition and return position
        GameObject pos = CheckContainerPos();
        if (pos != null)
        {
            GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            crate.transform.SetParent(pos.transform);
            PutItemstoCrate(crate, 14);
        }
        else
        {
            Debug.Log("Cannot Spawn anymore");
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
