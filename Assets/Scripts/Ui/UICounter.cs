using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICounter : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI counterText;
    public void StartAnim()
    {
        animator.SetTrigger("CounterStart");
    }

    public void UpdateText(string text)
    {
        counterText.text = text;
    }
}
