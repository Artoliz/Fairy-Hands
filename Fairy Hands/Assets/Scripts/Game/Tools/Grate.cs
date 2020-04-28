using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Grate : MonoBehaviour
{
    public float Magnitude = 2.0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            var velocityEstimator = GetComponentInParent<VelocityEstimator>();
            if (velocityEstimator)
            {
                var modifier = other.gameObject.GetComponent<Modifier>();
                if (modifier)
                    modifier.ApplyModification();
            }
        }
    }
}
