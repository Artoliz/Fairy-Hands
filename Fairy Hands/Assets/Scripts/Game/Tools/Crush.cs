using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Crush : MonoBehaviour
{
    public float Magnitude = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ingredient"))
        {
            var ing = other.GetComponent<Ingredient>();
            if (ing && ing._action == Ingredient.Action.Crushable)
            {
                var velocityEstimator = GetComponentInParent<VelocityEstimator>();
                if (velocityEstimator && velocityEstimator.GetVelocityEstimate().magnitude > Magnitude)
                {
                    var modifier = other.gameObject.GetComponent<Modifier>();
                    if (modifier)
                        modifier.ApplyModification();
                }
            }
        }
    }
}
