using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiHighscore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hsText;
    [SerializeField] private Animator animator;
    public void SetHighscore(float hs)
    {
        hsText.text = hs.ToString("N0");
        animator.SetTrigger("NewHs");
    }
}
