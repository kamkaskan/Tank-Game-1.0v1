using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITankHp : MonoBehaviour
{
    [SerializeField] private Image hpFill;
    // Update is called once per frame
    public void UpdateHp(float perc)
    {
        hpFill.fillAmount = perc;
    }

    void OnEnable()
    {
        UpdateHp(1);
    }
}
