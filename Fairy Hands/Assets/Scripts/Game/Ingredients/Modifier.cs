using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class Modifier : MonoBehaviour
{
    public GameObject NextModifier = null;

    public int MaxHit = 1;

    public int MaxHitTotal = 0;

    public int CurrentHit = 0;

    public Transform ProgressBar;

    public void Update()
    {
        ProgressBar.eulerAngles = new Vector3(-transform.rotation.x, -transform.rotation.y, -transform.rotation.z);
    }
    
    public void ApplyModification()
    {
        CurrentHit += 1;
        if (GetComponentInChildren<ProgressBarCustom>())
            GetComponentInChildren<ProgressBarCustom>().OnHitChanged(CurrentHit, MaxHitTotal);
        if (CurrentHit >= MaxHit)
        {
            GameObject tmp = Instantiate(NextModifier, this.transform.position, Quaternion.identity);
            Modifier modifier = tmp.GetComponent<Modifier>();
            if (modifier)
            {
                modifier.CurrentHit = CurrentHit;
                modifier.MaxHitTotal = MaxHitTotal;
                tmp.GetComponentInChildren<ProgressBarCustom>().OnHitChanged(CurrentHit, MaxHitTotal);
            }
            Destroy(this.gameObject);
        }
    }
}
