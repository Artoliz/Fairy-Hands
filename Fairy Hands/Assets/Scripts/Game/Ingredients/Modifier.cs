using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modifier : MonoBehaviour
{
    public GameObject NextModifier = null;

    public int MaxHit = 1;

    public int MaxHitTotal = 0;

    public int CurrentHit = 0;

    public void ApplyModification()
    {
        CurrentHit += 1;
        if (GetComponentInChildren<ProgressBarCustom>())
            GetComponentInChildren<ProgressBarCustom>().OnHitChanged();
        if (CurrentHit == MaxHit)
        {
            GameObject tmp = Instantiate(NextModifier, this.transform.position, Quaternion.identity);
            Modifier modifier = tmp.GetComponent<Modifier>();
            if (modifier)
            {
                tmp.GetComponentInChildren<ProgressBarCustom>()._maxSizeX = GetComponentInChildren<ProgressBarCustom>()._maxSizeX;
                tmp.GetComponentInChildren<ProgressBarCustom>()._size = GetComponentInChildren<ProgressBarCustom>()._size;
                tmp.GetComponentInChildren<ProgressBarCustom>().OnHitChanged();
            }
            Destroy(this.gameObject);
        }
    }
}
