using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{  
    public GameObject prefabToSpawn;
    public GameObject sphere;
    public GameObject cannedBeer;
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Check spawnposition and return position
            GameObject pos = CheckContainerPos();
            if (pos != null)
            {
                GameObject crate = Instantiate(prefabToSpawn, pos.transform.position, Quaternion.identity);
                crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                crate.transform.SetParent(pos.transform);
                PutItemstoCrate(crate);
            }
            else
            {
                Debug.Log("Cannot Spawn anymore");
            }


        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(prefabToSpawn, spawnPosition.transform.GetChild(1).position, Quaternion.identity);
            for (int x = 0; x < 6; x++)
            {
                obj[x] = Instantiate(cannedBeer, prefabToSpawn.GetComponent<CrateManager>().itemPos[x].gameObject.transform.position, Quaternion.identity);
                //obj.transform.SetParent(obj.GetComponent<CrateManager>().items[x].gameObject.transform);
                //obj.GetComponent<CrateManager>().SetToKinematic();
            }
        }

        
    }

    
    private void PutItemstoCrate(GameObject crate)
    {
        for (int x = 0; x < 6; x++)
        {
            obj[x] = Instantiate(cannedBeer, crate.transform.GetComponent<CrateManager>().itemPos[x].transform.localPosition,
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
