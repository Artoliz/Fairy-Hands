using UnityEngine;
 
public class Floater : MonoBehaviour {
    #region PrivateVariables

    private Vector3 posOffset;
    private Vector3 tempPos;

    #endregion

    #region SeriazableFields

    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private float frequency = 1f;

    #endregion

    private void Start () {
        posOffset = transform.position;
    }
     
    private void Update () {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
    }
}