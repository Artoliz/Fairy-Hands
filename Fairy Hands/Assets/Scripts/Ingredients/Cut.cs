using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Cut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            var velocityEstimator = GetComponentInParent<VelocityEstimator>();
            if (velocityEstimator && velocityEstimator.GetVelocityEstimate().magnitude > 2.0f)
            {
                var modifier = other.gameObject.GetComponent<Modifier>();
                if (modifier)
                    modifier.ApplyModification();
            }
        }
    }
}
