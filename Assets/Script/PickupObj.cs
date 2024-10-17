using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickupLayerMask;
    public Transform objectGrabPointTransform;
    private float pickupDistance;
    private ObjectGrabbable objectGrabbable;
    // Start is called before the first frame update
    void Start()
    {
        pickupDistance = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (objectGrabbable == null)
            {
                if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabbable);
                    }

                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
    }
}
