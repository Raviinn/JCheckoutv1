using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    public GameObject[] item;
    private bool isAvailable;
    private int objIndex;
    private ObjectGrabbable obj;

    public Material highlightMAterial;
    private Material originalMaterial;
    // Start is called before the first frame update
    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
        isAvailable = false;
        for (int i = 0; i < item.Length; i++)
        {
            if (item[i].transform.childCount == 0)
            {
                item[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public Vector3? ChkContainerObjPos()
    {
        bool isAvailable = false; // Declare isAvailable to check item availability
        int objIndex = -1; // Initialize objIndex to -1 for safety

        for (int i = 0; i < item.Length; i++)
        {
            if (!item[i].activeSelf)
            {
                item[i].SetActive(true);
                isAvailable = true;
                objIndex = i;
                break;
            }
        }

        // If no available item is found, return null
        if (!isAvailable || objIndex == -1)
        {
            return null; // Returning null if no active items
        }

        // Return the position of the active item
        return item[objIndex].transform.position;
    }

    public void RemoveObj(Vector3 position)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (item[i].transform.position == position)
            {
                item[i].SetActive(false);
                Debug.Log("Removed from container");
                break;
            }
        }
    }

    public void HighlightObject()
    {
        GetComponent<MeshRenderer>().material = highlightMAterial;
    }

    public void RemoveHighlight()
    {
        GetComponent<MeshRenderer>().material = originalMaterial;
    }
}
