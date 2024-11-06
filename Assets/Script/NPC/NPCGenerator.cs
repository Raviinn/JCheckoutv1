using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGenerator : MonoBehaviour
{
    public GameObject[] npcToSpawn;
    public bool isMArtOpen;
    public int npcCounter;
    private GameObject npcCheckpoints;
    // Start is called before the first frame update
    void Start()
    {
        npcCounter = 0;
        npcCheckpoints = GameObject.Find("NPCCheckPoints");
        isMArtOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMArtOpen && npcCounter < 3)
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
