using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Board : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ingredient"))
        {
            if (collision.gameObject.GetComponent<Ingredient>()._state != Ingredient.State.InHand)
            {
                collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                if (collision.gameObject.GetComponent<MeshCollider>() && collision.gameObject.GetComponent<MeshCollider>().isTrigger == false)
                {
                    collision.gameObject.GetComponent<MeshCollider>().isTrigger = true;
                }
                if (collision.gameObject.GetComponent<BoxCollider>() && collision.gameObject.GetComponent<BoxCollider>().isTrigger == false)
                {
                    collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                }
            }
            collision.gameObject.GetComponent<Ingredient>()._state = Ingredient.State.OverBoard;
        }
    }
}
