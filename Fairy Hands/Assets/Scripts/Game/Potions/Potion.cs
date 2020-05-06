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
                _positions.Add(child.position);
        }
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3.MoveTowards(transform.position, _destination, Time.deltaTime * Speed);
            if (Vector3.Distance(transform.position, _destination) <= 0.1f)
                isMoving = false;
        }
    }

    public void GoToChest()
    {
        isMoving = true;
        if (_positions.Count > 0)
            _destination = _positions[Random.Range(0, _positions.Count - 1)];
    }
}
