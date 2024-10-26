using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectGrabbable : MonoBehaviour
{
    public Rigidbody rb;
    private Transform grabPointTransform, container;
    ObjectContainer objContainer;

    public Material highlightMAterial;
    private Material originalMaterial;
    private Vector3 getPosition;
    public bool isInContainer;

    public bool isInCrate;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalMaterial = GetComponent<Renderer>().material;
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
        obj.transform.position = getPosition;
        this.grabPointTransform = null;
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    public void PickupFromContainer(Transform grabPointTransform)
    {
        this .grabPointTransform = grabPointTransform;
        this.objContainer.RemoveObj(getPosition); 
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
