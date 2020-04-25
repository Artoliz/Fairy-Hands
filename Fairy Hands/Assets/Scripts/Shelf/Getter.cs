using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Getter : MonoBehaviour
{
    public GameObject Prefab;

    private void OnTriggerStay(Collider other)
    {
        Hand hand = null;

        if (other.CompareTag("PlayerRightHand"))
            hand = other.GetComponentInParent<Player>().rightHand;
        else if (other.CompareTag("PlayerLeftHand"))
            hand = other.GetComponentInParent<Player>().leftHand;

        if (hand == null)
            return;

        if (hand.currentAttachedObject == null && hand.GetGrabStarting() == GrabTypes.Pinch)
        {
            GameObject prefab = Instantiate(Prefab);
            hand.AttachObject(prefab, GrabTypes.Pinch);
        }
    }
}
