using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    public GameObject[] npcToSpawn;
    public bool isMartOpen;
    public int npcCounter;
    private GameObject npcCheckpoints;
    public bool isTooLateforCustomers;
    // Start is called before the first frame update
    void Start()
    {
        npcCounter = 0;
        npcCheckpoints = GameObject.Find("NPCCheckPoints");
        isMartOpen = false;
        isTooLateforCustomers = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isMartOpen);
        if (isMartOpen && npcCounter < 3 && !isTooLateforCustomers)
        {
            //Generate NPC
            //Generate a number to verify which NPC to spawn
            int npcRandomSpawn = Random.Range(0, 8000);
            if (npcRandomSpawn < 5)
            {
                int npcRandomSpawnLoc = Random.Range(1, 3);
                GameObject npcSpawn = Instantiate(npcToSpawn[npcRandomSpawn], npcCheckpoints.transform.Find($"ExitPoint{npcRandomSpawnLoc}").transform.position, Quaternion.identity);
                npcSpawn.transform.SetParent(GameObject.Find("CustomerNPCs").transform);
                npcCounter++;
            }
        }
    }
}
