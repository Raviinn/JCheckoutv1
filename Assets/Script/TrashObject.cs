using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour
{
    public GameObject trash;
    private GameObject trashSpawnPoints;
    public Material highlightMaterial;
    public Material originalMaterial;
    // Start is called before the first frame update
    void Start()
    {
        trashSpawnPoints = GameObject.Find("TrashSpawnPoints");
        originalMaterial = trash.transform.GetChild(0).GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Clean()
    {
        Debug.Log("Henlo");
        trash.transform.SetParent(null);
        GameObject.Find("Player").GetComponent<PlayerManager>().playerMoney += 5;
        GameObject.Find("Player").GetComponent<PlayerManager>().DisplayPlayerMoney();
        Destroy(trash);
    }

    public void RemoveHighLight()
    {
        trash.transform.GetChild(0).GetComponent<MeshRenderer>().material = originalMaterial;


    }

    public void Highlight()
    {
        trash.transform.GetChild(0).GetComponent<MeshRenderer>().material = highlightMaterial;
    }
}
