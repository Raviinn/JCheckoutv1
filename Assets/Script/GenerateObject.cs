using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{  
    public GameObject prefabToSpawn;
    public GameObject sphere;
    public GameObject cannedBeer;
    private Vector3 spawnPosition;
    private GameObject[] obj = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3(0, 3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
          
            GameObject crate = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            crate.transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
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

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            for (int x = 0; x < 6; x++)
            {
                obj[x] = Instantiate(cannedBeer, prefabToSpawn.GetComponent<CrateManager>().itemPos[x].gameObject.transform.position, Quaternion.identity);
                //obj.transform.SetParent(obj.GetComponent<CrateManager>().items[x].gameObject.transform);
                //obj.GetComponent<CrateManager>().SetToKinematic();
            }
        }
    }
}
