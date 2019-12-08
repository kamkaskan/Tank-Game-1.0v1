using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMainMenu : MonoBehaviour
{
    [SerializeField] private UiDifficultyButtons difficultyButtons;
    [SerializeField] private UiPlusMinusButtons playerTankButtons;
    [SerializeField] private UiPlusMinusButtons aiTankButtons; 
    [SerializeField] private UiPlusMinusButtons aiAmountButtons;
    [SerializeField] private UIMapList mapList;
    public void ClickStart()
    {
        DataHolder.instance.StartGame(difficultyButtons.GetDifficulty(), playerTankButtons.value - 1, aiTankButtons.value -1, aiAmountButtons.value, mapList.value);
        LoadingSystem.instance.LoadScene("MapScene");
    }
    
}
