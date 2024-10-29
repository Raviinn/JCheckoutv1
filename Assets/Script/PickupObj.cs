using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool isContainer;
    private bool canDropObj;
    void Start()
    {
        pickupDistance = 7f;
        isGrabbingCrate = false;
        canDropObj = true;
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
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable) && !objectGrabbable.isContainer)
                    {
                        if (objectGrabbable.isInContainer)
                        {
                            objectGrabbable.rb.isKinematic = false;
                            objectGrabbable.PickupFromContainer(objectGrabPointTransform);
                            objectGrabbable.isInContainer = false;
                        }
                        else if (objectGrabbable.isInCrate)
                        {
                            objectGrabbable.rb.isKinematic = false;
                        }

                        objectGrabbable.Grab(objectGrabPointTransform);

                    }
                    else if (raycastHit.transform.TryGetComponent(out objectGrabbable) && objectGrabbable.isContainer)
                    {
                        Debug.Log("Pickup Container");
                        objectGrabbable.Grab(objectGrabPointTransform);
                        isGrabbingCrate = true;
                    }
                }
            }
            else //Player has an object (DROP OBJECT)
            {
                if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                    out RaycastHit raycastHit, pickupDistance, pickupLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectContainer) &&
                        !isGrabbingCrate)// Place object in container
                    {
                        Debug.Log("Container");
                        objectGrabbable.PlaceObjToContainer(objectContainer);
                        if (objectGrabbable.getPosition != null)
                        {
                            objectGrabbable.isInContainer = true;
                            objectGrabbable.rb.isKinematic = true;
                            objectGrabbable = null;
                        }
                        
                    }
                    else if (raycastHit.transform.TryGetComponent(out objectContainer) &&
                        isGrabbingCrate)//Place objects in crate to container
                    {
                        Debug.Log("Grabbing Container");
                        objectGrabbable.PlaceCrateItemsToContainer(objectContainer);
                        canDropObj = false;

                    }
                    else
                    {
                        canDropObj = true;
                        objectGrabbable.Drop();
                        objectGrabbable = null;
                    }

                }
                else
                {

                    if (objectGrabbable.isInCrate && !isGrabbingCrate)//object was grabbed from crate and is
                                                                      //not grabbing crate
                    {
                        objectGrabbable.rb.isKinematic = false;
                        canDropObj = true;
                    }


                    if (canDropObj)
                    {
                        if (isGrabbingCrate)
                        {
                            isGrabbingCrate = false;
                        }
                        objectGrabbable.Drop();
                        objectGrabbable = null;
                    }
                    else if (isGrabbingCrate && !canDropObj)
                    {
                        canDropObj = true;
                        objectGrabbable.Drop();
                        objectGrabbable = null;
                        isGrabbingCrate = false;
                    }
                }
            
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(objectGrabbable);
            if (objectGrabbable != null && !isGrabbingCrate)
            {
                objectGrabbable.Throw();
                objectGrabbable = null;
                canDropObj = true;
            }
            else if (crateManager != null)
            {
                crateManager.Throw();
                crateManager = null;
                canDropObj = true;

            }
            else if (objectGrabbable != null && isGrabbingCrate)
            {
                Debug.Log("Hello");
                objectGrabbable.Throw();
                objectGrabbable = null;
                isGrabbingCrate = false;
                canDropObj = true;
            }
        }
    }

    private void HandleHighlight()
    {
        if (objectGrabbable == null)//no object being grabbed
        {
            if (currentHighlightedObjectContainer != null)
            {
                currentHighlightedObjectContainer.RemoveHighlight();
                currentHighlightedObjectContainer = null;
            }

            if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                        out RaycastHit raycasthit, pickupDistance, pickupLayerMask))
            {
                if (raycasthit.transform.TryGetComponent(out ObjectGrabbable newObjectGrabbable))
                {
                    if (currentHighlightedObject != newObjectGrabbable)
                    {

                        if (currentHighlightedObject != null)
                        {
                            currentHighlightedObject.RemoveHighlight(); 
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
                    currentHighlightedObject.RemoveHighlight(); 
                    currentHighlightedObject = null;
                }
            }
        }
        else
        {
            if (Physics.Raycast(playerCamera.position, playerCamera.forward,
                        out RaycastHit raycasthit, pickupDistance, pickupLayerMask))
                if (raycasthit.transform.TryGetComponent(out ObjectContainer newObjectContainer)){
                    if (currentHighlightedObjectContainer != newObjectContainer)
                    {

                        if (currentHighlightedObjectContainer != null)
                        {
                            currentHighlightedObjectContainer.RemoveHighlight(); 
                        }

                        // Highlight the new object
                        currentHighlightedObjectContainer = newObjectContainer;
                        currentHighlightedObjectContainer.HighlightObject();
                    }
                }
                else
                        // No valid object, remove highlight
                        if (currentHighlightedObjectContainer != null)
                {
                    currentHighlightedObjectContainer.RemoveHighlight(); 
                    currentHighlightedObjectContainer = null;
                }
        

            // Raycast did not hit anything, remove highlight
            if (currentHighlightedObject != null)
            {
                currentHighlightedObject.RemoveHighlight(); 
                currentHighlightedObject = null;
            }
        }
     }
}
