using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PickupObj : MonoBehaviour
{
    public Transform playerCamera;
    public LayerMask pickupLayerMask;
    public Transform objectGrabPointTransform;
    private float pickupDistance;
    private ObjectGrabbable objectGrabbable;
    private ObjectContainer objectContainer;
    private ObjectGrabbable currentHighlightedObject;
    private ObjectContainer currentHighlightedObjectContainer;
    private CrateManager crateManager;
    private bool isGrabbingCrate;
    void Start()
    {
        pickupDistance = 7f;
        isGrabbingCrate = false;
    }

    void Update()
    {
        HandlePickup();
        HandleHighlight();
    }

    private void HandlePickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null && crateManager == null) // Player not holding any object(PICKUP OBJECT)
            {
                if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                    out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        if (objectGrabbable.isInContainer)
                        { 
                            objectGrabbable.rb.isKinematic = false;
                            objectGrabbable.PickupFromContainer(objectGrabPointTransform);
                            objectGrabbable.isInContainer = false;
                        }else if (objectGrabbable.isInCrate)
                        {
                            objectGrabbable.rb.isKinematic = false;
                        }
                        objectGrabbable.Grab(objectGrabPointTransform);

                    }else if (raycastHit.transform.TryGetComponent(out crateManager))
                    {
                        crateManager.Grab(objectGrabPointTransform);
                        isGrabbingCrate = true;
                    }
                }
            }
            else //Player has an object (DROP OBJECT)
            {
                if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                    out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectContainer))
                    {
                        Debug.Log("Container");
                        objectGrabbable.PlaceObjToContainer(objectContainer);
                        objectGrabbable.isInContainer = true;
                        objectGrabbable.rb.isKinematic = true;
                    } 
                }

                if (isGrabbingCrate)
                {
                    crateManager.Drop();
                    crateManager = null;
                    isGrabbingCrate = false;
                }

                if (objectGrabbable.isInCrate)
                {
                    objectGrabbable.rb.isKinematic = false;
                }
                    objectGrabbable.Drop();
                    objectGrabbable = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (objectGrabbable != null && !isGrabbingCrate)
            {
                objectGrabbable.Throw();
                objectGrabbable = null;
            }else if (crateManager != null)
            {
                crateManager.Throw();
                crateManager = null;
                isGrabbingCrate = false;
            }else if (objectGrabbable != null && isGrabbingCrate)
            {
                objectGrabbable.rb.isKinematic = true;
                objectGrabbable.Throw();
                objectGrabbable = null;
            }
        }
    }

    private void HandleHighlight()
    {
        if (objectGrabbable == null)
        {
            
            if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                        out RaycastHit raycasthit, pickupDistance, pickupLayerMask))
            {
                if (raycasthit.transform.TryGetComponent(out ObjectGrabbable newObjectGrabbable))
                {

                    if (currentHighlightedObject != newObjectGrabbable)
                    {

                        if (currentHighlightedObject != null)
                        {
                            currentHighlightedObject.RemoveHighlight(); // Assuming this method exists
                        }

                        // Highlight the new object
                        currentHighlightedObject = newObjectGrabbable;
                        currentHighlightedObject.HighlightObject();
                    }
                }
                else
                    // No valid object, remove highlight
                    if (currentHighlightedObject != null)
                    {
                        currentHighlightedObject.RemoveHighlight(); // Assuming this method exists
                        currentHighlightedObject = null;
                    }
                }
            }
            else
            {
                // Raycast did not hit anything, remove highlight
                if (currentHighlightedObject != null)
                {
                    currentHighlightedObject.RemoveHighlight(); // Assuming this method exists
                    currentHighlightedObject = null;
                }
            }
     }
}
