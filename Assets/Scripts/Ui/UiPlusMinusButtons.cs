using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiPlusMinusButtons : MonoBehaviour
{
    [SerializeField] private int min;
    [SerializeField] private int max;
    [SerializeField] private int changeAmount;
    public int value {get; private set;}
    [SerializeField] private TextMeshProUGUI valueText;
    void Awake()
    {
        value = min;
        UpdateTexts();
    }
    public void ClickButton(int mod)
    {
        value += changeAmount * mod;
        if (value > max) value = max;
        if (value < min) value = min;
        UpdateTexts();
    }

    void UpdateTexts()
    {
        valueText.text = value.ToString();
    }
}
