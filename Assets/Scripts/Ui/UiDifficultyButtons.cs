using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiDifficultyButtons : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    private int clickedButton;
    void Awake()
    {
        UpdateButtons(-1, clickedButton);
    }
    public void ClickButton(int i)
    {
        UpdateButtons(clickedButton, i);
        clickedButton = i;
    }

    void UpdateButtons(int oldButton, int newButton)
    {
        if (oldButton != -1) buttons[oldButton].interactable = true;
        buttons[newButton].interactable = false;
    }

    public int GetDifficulty()
    {
        return clickedButton;
    }
}
