using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarCustom : MonoBehaviour
{
    public Transform Progress;

    public Transform CameraPos;

    private void Awake()
    {
        Progress.localScale = new Vector3(0, 0.8f, 10);;

    }

    private void Update()
    {
        transform.LookAt(CameraPos);
       //transform.LookAt(camera.transform);
    }
    public void OnHitChanged(int currentHit, int maxHitTotal)
    {
        Progress.localScale = new Vector3(((float)currentHit / (float)maxHitTotal) * 0.9f, 0.8f, 10);
    }
}
