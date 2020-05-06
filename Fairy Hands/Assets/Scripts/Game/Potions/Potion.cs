using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private bool isMoving = false;
    private List<Vector3> _positions = new List<Vector3>();
    private Vector3 _destination = new Vector3();

    private Transform Chest = null;
    [SerializeField] private int Speed = 2;

    private void Awake()
    {
        Chest = GameObject.Find("Chest_Open").transform;
        foreach (Transform child in Chest)
        {
            if (child.name.Contains("Cube"))
                _positions.Add(child.localPosition);
        }
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3.MoveTowards(transform.localPosition, _destination, Time.deltaTime * Speed);
        }
    }

    public void GoToChest()
    {
        isMoving = true;
        GetComponent<Rigidbody>().useGravity = false;
        transform.SetParent(Chest);
        if (_positions.Count > 0)
        {
            _destination = _positions[Random.Range(0, _positions.Count - 1)];
        }
    }
}
