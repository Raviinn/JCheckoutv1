using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{
    public GameObject crate;
    public GameObject[] itemPos;
    public GameObject obj;
    public Material highlightMAterial;
    public Material originalMaterial;
    private Transform grabPointTransform;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabPointTransform != null)
        {
            float lerpSpeed = 70f;
            Vector3 newPosition = Vector3.Lerp(transform.position, grabPointTransform.position,
                Time.deltaTime * lerpSpeed);
            crate.GetComponent<Rigidbody>().MovePosition(newPosition);
            crate.GetComponent<Rigidbody>().useGravity = false;
            crate.GetComponent<Rigidbody>().freezeRotation = true;
            transform.rotation = Camera.main.transform.rotation;
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
        crate.GetComponent<Rigidbody>().useGravity = true;
    }

    public void Throw()
    {
        this.grabPointTransform = null;
        Vector3 throwDirection = Camera.main.transform.forward;
        crate.GetComponent<Rigidbody>().useGravity = true; // Ensure the Rigidbody is not kinematic
        crate.GetComponent<Rigidbody>().AddForce(throwDirection * 10f, ForceMode.Impulse);
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
