using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Chest : MonoBehaviour
{
    private List<Vector3> _positions = new List<Vector3>();

    private int _offset = 0;

    private void Start()
    {
        foreach (Transform child in transform)
            _positions.Add(child.transform.localPosition);

        ShufflePositions();
    }

    private System.Random rng = new System.Random();

    public void ShufflePositions()
    {
        int n = _positions.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Vector3 value = _positions[k];
            _positions[k] = _positions[n];
            _positions[n] = value;
        }
    }

    public void SetPotion(GameObject potion)
    {
        foreach (Hand hand in Player.instance.hands)
        {
            foreach (var objects in hand.AttachedObjects)
            {
                if (objects.attachedObject == potion)
                {
                    hand.DetachObject(objects.attachedObject);
                    break;
                }
            }
        }

        potion.transform.SetParent(transform);
        potion.transform.localPosition = _positions[_offset];
        _offset += 1;
        if (_offset >= _positions.Count)
            _offset = 0;
    }
}
