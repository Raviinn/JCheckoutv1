using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectGrabbable : MonoBehaviour
{
    public Rigidbody rb;
    private Transform grabPointTransform, container;
    ObjectContainer objContainer;

    public Material highlightMaterial;
    private Material originalMaterial;
    public Vector3? getPosition;
    public bool isInContainer;
    private Vector3 originalVelocity, originalAngularVelocity;
    private Material[] getMaterials;
    public GameObject Mesh;
    public bool isContainer;
    public bool isSpawnedItem;
    private bool isGrabbedFirstTime;
    private int containerObjCounter;
   
    public bool isInCrate;
    public GameObject obj;
    private GameObject objOriginalSetting;
    private GenerateObject generateObject;
    private PlayerManager playerManager;
    private GameObject Objects;
    public float objectPrice;
    public string objectName;
    // Start is called before the first frame update
    void Start()
    {
        generateObject = FindObjectOfType<GenerateObject>();
        isGrabbedFirstTime = true;
        rb = GetComponent<Rigidbody>();
        containerObjCounter = 0;
        //originalMaterial = GetComponent<Renderer>().material;
        isInContainer = false;
        isSpawnedItem = false;
        playerManager = FindObjectOfType<PlayerManager>();
        Objects = GameObject.Find("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        if (grabPointTransform != null)
        { 
            float lerpSpeed = 80f;
            Vector3 newPosition = Vector3.Lerp(transform.position, grabPointTransform.position, 
                Time.deltaTime * lerpSpeed);
            rb.MovePosition(newPosition);
            obj.transform.SetParent(playerManager.transform.GetChild(2));
            originalAngularVelocity = rb.angularVelocity;
            originalVelocity = rb.velocity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.rotation = Camera.main.transform.rotation;
            rb.useGravity = false;
            RemoveHighlight();
        }

    }

    public void Grab(Transform grabPointTransform)
    {
        this.grabPointTransform = grabPointTransform;

    }

    public void Drop()
    {  
        this.grabPointTransform = null;
        rb.useGravity = true;
        rb.velocity = originalAngularVelocity;
        rb.angularVelocity = originalVelocity;
        obj.transform.SetParent(Objects.transform);
    }

    public void Throw()
    {
        this.grabPointTransform = null;
        Vector3 throwDirection = Camera.main.transform.forward;
        rb.useGravity = true; // Ensure the Rigidbody is not kinematic
        rb.AddForce(throwDirection * 10f, ForceMode.Impulse);
        obj.transform.SetParent(Objects.transform);
    }

    public void PlaceObjToContainer(ObjectContainer objContainer)
    {
        this.objContainer = objContainer;
        getPosition = this.objContainer.ChkContainerObjPos();
        if (getPosition == null)
        {
            Debug.Log("No More Space");
            return;
        }
        GameObject foundChild = GetChildByPosition(objContainer.transform, getPosition.Value);
        obj.transform.transform.SetParent(foundChild.transform);
        obj.transform.position = getPosition.Value;
        obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        grabPointTransform = null;
        Debug.Log(rb.isKinematic);
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void PickupFromContainer(Transform grabPointTransform)
    {
        GameObject objects = GameObject.Find("Objects");
        this .grabPointTransform = grabPointTransform;
        this.objContainer.RemoveObj(getPosition.Value);
        obj.transform.SetParent(objects.transform);
    }

    public void HighlightObject()
    {
        // Get the MeshRenderer and its materials
        MeshRenderer meshRenderer = Mesh.GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogError("No MeshRenderer found on the specified Mesh GameObject.");
            return;
        }

        Material[] materials = meshRenderer.materials;
        //Debug.Log("Number of materials: " + materials.Length);

        // Store original materials if not already done
        if (getMaterials == null || getMaterials.Length == 0)
        {
            getMaterials = new Material[materials.Length];
            for (int i = 0; i < materials.Length; i++)
            {
                getMaterials[i] = materials[i]; // Store original material
                //Debug.Log("Original Material: " + getMaterials[i].name);
            }
        }

        // Ensure highlightMaterial is assigned
        if (highlightMaterial == null)
        {
            Debug.LogError("Highlight material is not assigned!");
            return;
        }

        // Change to highlight material
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = highlightMaterial; // Set the material to highlight material
            //Debug.Log("Highlighted Material: " + materials[i].name);
        }

        // Update the materials in the MeshRenderer
        meshRenderer.materials = materials; // Update the materials
    }

    public void RemoveHighlight()
    {
        MeshRenderer meshRenderer = Mesh.GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogError("No MeshRenderer found on the specified Mesh GameObject.");
            return;
        }

        if (getMaterials != null && getMaterials.Length > 0)
        {
            // Restore original materials
            Material[] materials = meshRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = getMaterials[i]; // Set back to original material
                //Debug.Log("Restored Material: " + materials[i].name);
            }

            // Update the materials in the MeshRenderer
            meshRenderer.materials = materials; // Update the materials
        }
        else
        {
            Debug.LogWarning("Original materials are not stored; cannot remove highlight.");
        }
    }

    public void PlaceCrateItemsToContainer(ObjectContainer objectContainer)
    {
        this.objContainer = objectContainer;

        //Get and store all objects inside container
        containerObjCounter++;
        getPosition = this.objContainer.ChkContainerObjPos();
        if (getPosition != null)
        {
            obj.transform.Find($"ItemPos{containerObjCounter}").GetChild(0).transform.position = getPosition.Value;
            obj.transform.Find($"ItemPos{containerObjCounter}").GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
            obj.transform.Find($"ItemPos{containerObjCounter}").GetChild(0).GetComponent<Rigidbody>().useGravity = false;
            obj.transform.Find($"ItemPos{containerObjCounter}").GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
            GameObject foundChild = GetChildByPosition(objectContainer.transform, getPosition.Value);
            obj.transform.Find($"ItemPos{containerObjCounter}").GetChild(0).transform.SetParent(foundChild.transform);
            Debug.Log(obj.transform.Find($"ItemPos{containerObjCounter}").name);
            return;
        }
        Debug.Log("No More Space");
        //this.grabPointTransform = null;
    }

    GameObject GetChildByPosition(Transform parent, Vector3 position)
    {
        foreach (Transform child in parent)
        {
            // Check if the child's position matches the target position
            if (child.position == position)
            {
                return child.gameObject; // Return the matching child GameObject
            }
        }
        return null; // Return null if no matching child is found
    }
}

    

