using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonAutoRotate : MonoBehaviour
{
    public float _speed = 50;
    private Vector3 _axis = new Vector3(0, 1, 0);

    void Update()
    {
        transform.Rotate(_axis, _speed * Time.deltaTime, Space.World);
    }
}
