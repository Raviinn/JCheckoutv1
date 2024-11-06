using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObjectGenerator : MonoBehaviour
{
    public GameObject trashtoSpawn;
    private GameObject trashSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        trashSpawnPoint = GameObject.Find("TrashSpawnPoints");
    }

    // Update is called once per frame
    void Update()
    {
        int spawnNum = Random.Range(0, 10000);
        if (spawnNum < 4 && !GameObject.Find("DirectionalLight").GetComponent<DayandNightManager>().isEndOfDay)
        {
            if (trashSpawnPoint.transform.GetChild(spawnNum).childCount == 0)
            {
                GameObject obj =  Instantiate(trashtoSpawn, trashSpawnPoint.transform.GetChild(spawnNum).transform.position, Quaternion.identity);
                obj.transform.SetParent(trashSpawnPoint.transform.GetChild(spawnNum).transform);
                
            }
        }
    }
}
