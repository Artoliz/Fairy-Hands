using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarCustom : MonoBehaviour
{
    public Transform Progress;

    private void Awake()
    {
        Progress.localScale = new Vector3(0, 0.8f, 10);;

    }

    private void Update()
    {
        transform.LookAt(GameObject.Find("VRCamera").transform);
    }
    public void OnHitChanged(int currentHit, int maxHitTotal)
    {
        Progress.localScale = new Vector3(((float)currentHit / (float)maxHitTotal) * 0.9f, 0.8f, 10);
    }
}
