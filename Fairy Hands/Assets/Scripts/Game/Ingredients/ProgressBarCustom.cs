using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarCustom : MonoBehaviour
{
    public float _maxSizeX;
    public Vector3 _size;

    public Transform Progress;

    private void Start()
    {
        _maxSizeX = Progress.localScale.x;
        _size = Progress.localScale;
    }

    private void Update()
    {
        transform.LookAt(GameObject.Find("VRCamera").transform);
    }

    public void OnHitChanged()
    {
        Modifier parent = GetComponentInParent<Modifier>();

        float currentSizeX = _maxSizeX / parent.MaxHitTotal;
        Progress.localScale = new Vector3(_size.x - currentSizeX, _size.y, _size.z);
        _size = Progress.localScale;
    }
}
