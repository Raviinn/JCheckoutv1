using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectGrabbable : MonoBehaviour
{
    public Rigidbody rb;
    private Transform grabPointTransform, container;
    ObjectContainer objContainer;

    public Material highlightMaterial;
    private Material originalMaterial;
    private Vector3? getPosition;
    public bool isInContainer;
    private Vector3 originalVelocity, originalAngularVelocity;
    private Material[] getMaterials;
    public GameObject Mesh;
    public bool isContainer;

    public bool isInCrate;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //originalMaterial = GetComponent<Renderer>().material;
        isInContainer = false;
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
    }

    public void Throw()
    {
        this.grabPointTransform = null;
        Vector3 throwDirection = Camera.main.transform.forward;
        rb.useGravity = true; // Ensure the Rigidbody is not kinematic
        rb.AddForce(throwDirection * 10f, ForceMode.Impulse);
    }

    public void PlaceObjToContainer(ObjectContainer objContainer)
    {
        this.objContainer = objContainer;
        getPosition = this.objContainer.ChkContainerObjPos();
        obj.transform.position = getPosition.Value;
        obj.transform.rotation = Quaternion.Euler(0, 0, 0);
        this.grabPointTransform = null;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void PickupFromContainer(Transform grabPointTransform)
    {
        this .grabPointTransform = grabPointTransform;
        this.objContainer.RemoveObj(getPosition.Value); 
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
        for (int num = 0; num < 6; num++)
        {
            getPosition = this.objContainer.ChkContainerObjPos();
            if (getPosition == null)
            {
                break;
            }
            else
                obj.transform.Find($"Pos{num + 1}").GetChild(0).transform.position = getPosition.Value;
                obj.transform.Find($"Pos{num + 1}").GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
                obj.transform.Find($"Pos{num + 1}").GetChild(0).GetComponent<Rigidbody>().useGravity = false;
                obj.transform.Find($"Pos{num + 1}").GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
                Debug.Log(obj.transform.Find($"Pos{num + 1}").name);
        }
        //this.grabPointTransform = null;
    }
}

    

