using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateObject : MonoBehaviour
{  
    public GameObject prefabToSpawn;
    public GameObject sphere;
    public GameObject cube;
    private Vector3 spawnPosition;
    private GameObject[] obj = new GameObject[6];
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject crate = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            crate.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            for (int x = 0; x < 6; x++)
            {
                obj[x] = Instantiate(sphere, crate.GetComponent<CrateManager>().itemPos[x].transform.localPosition, 
                    Quaternion.identity);
                switch (x)
                {
                    case 0:
                        obj[x].transform.SetParent(crate.transform.Find("Cube/Pos1"));
                        break;
                    case 1:
                        obj[x].transform.SetParent(crate.transform.Find("Cube/Pos2"));
                        break;
                    case 2:
                        obj[x].transform.SetParent(crate.transform.Find("Cube/Pos3"));
                        break;
                    case 3:
                        obj[x].transform.SetParent(crate.transform.Find("Cube/Pos4"));
                        break;
                    case 4:
                        obj[x].transform.SetParent(crate.transform.Find("Cube/Pos5"));
                        break;
                    case 5:
                        obj[x].transform.SetParent(crate.transform.Find("Cube/Pos6"));
                        break;

                }
                
                obj[x].transform.localPosition = Vector3.zero;
                //obj[x].GetComponent<Rigidbody>().isKinematic = false;
                obj[x].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            for (int x = 0; x < 6; x++)
            {
                obj[x] = Instantiate(cube, prefabToSpawn.GetComponent<CrateManager>().itemPos[x].gameObject.transform.position, Quaternion.identity);
                //obj.transform.SetParent(obj.GetComponent<CrateManager>().items[x].gameObject.transform);
                //obj.GetComponent<CrateManager>().SetToKinematic();
            }
        }
    }
}
