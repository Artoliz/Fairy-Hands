using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class BasicInteractions : MonoBehaviour
{
    private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

    private Interactable interactable;

    private Vector3 StartingPos;

    void Awake()
    {
        interactable = this.GetComponent<Interactable>();

        if (this.tag == "Tool")
            StartingPos = this.transform.position;
    }


    //-------------------------------------------------
    // Called when a Hand starts hovering over this object
    //-------------------------------------------------
    private void OnHandHoverBegin(Hand hand)
    {
        //Debug.Log("OnHandHoverBegin");
    }


    //-------------------------------------------------
    // Called when a Hand stops hovering over this object
    //-------------------------------------------------
    private void OnHandHoverEnd(Hand hand)
    {
        //Debug.Log("OnHandHoverEnd");
    }


    //-------------------------------------------------
    // Called every Update() while a Hand is hovering over this object
    //-------------------------------------------------
    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            // Call this to continue receiving HandHoverUpdate messages,
            // and prevent the hand from hovering over anything else
            hand.HoverLock(interactable);

            // Attach this object to the hand
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
        else if (isGrabEnding)
        {
            // Detach this object from the hand
            hand.DetachObject(gameObject);

            // Call this to undo HoverLock
            hand.HoverUnlock(interactable);
        }
    }


    //-------------------------------------------------
    // Called when this GameObject becomes attached to the hand
    //-------------------------------------------------
    private void OnAttachedToHand(Hand hand)
    {
        if (this.tag == "Ingredient")
        {
            GetComponent<Ingredient>()._state = Ingredient.State.InHand;

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            if (GetComponent<MeshCollider>())
            {
                GetComponent<MeshCollider>().isTrigger = false;

            }
            else if (GetComponent<BoxCollider>())
            {
                GetComponent<BoxCollider>().isTrigger = false;
            }
            else if (GetComponent<SphereCollider>())
            {
                GetComponent<SphereCollider>().isTrigger = false;
            }
        }
    }


    //-------------------------------------------------
    // Called when this GameObject is detached from the hand
    //-------------------------------------------------
    private void OnDetachedFromHand(Hand hand)
    {
        if (this.tag == "Ingredient")
        {
            GetComponent<Ingredient>()._state = Ingredient.State.None;
        } else if (this.tag == "Potion")
        {
            foreach (Transform child in this.transform)
            {
                if (child.name == "Fill")
                {
                    var renderer = child.GetComponent<Renderer>();
                    if (renderer && !renderer.material.name.Contains("Empty"))
                    {
                        var potion = GetComponent<Potion>();
                        if (potion)
                            potion.GoToChest();
                    }
                }
            }
        } else if (this.tag == "Tool")
        {
            this.transform.position = StartingPos;
        }
    }


    //-------------------------------------------------
    // Called every Update() while this GameObject is attached to the hand
    //-------------------------------------------------
    private void HandAttachedUpdate(Hand hand)
    {
        //Debug.Log("HandAttachedUpdate");

    }

    //-------------------------------------------------
    // Called when this attached GameObject becomes the primary attached object
    //-------------------------------------------------
    private void OnHandFocusAcquired(Hand hand)
    {
        //Debug.Log("OnHandFocusAcquired");
    }


    //-------------------------------------------------
    // Called when another attached GameObject becomes the primary attached object
    //-------------------------------------------------
    private void OnHandFocusLost(Hand hand)
    {
        //Debug.Log("OnHandFocusLost");
    }
}
