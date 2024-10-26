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
            item[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public Vector3 ChkContainerObjPos()
    {
        for (int i = 0; i < item.Length; i++) {
            if (!item[i].activeSelf) {
                item[i].SetActive(true);
                isAvailable = true;
                objIndex = i;
                break;
            }
        }
        return (item[objIndex].transform.position);
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
        GetComponent<Renderer>().material = highlightMAterial;
    }

    public void RemoveHighlight()
    {
        GetComponent<Renderer>().material = originalMaterial;
    }
}
