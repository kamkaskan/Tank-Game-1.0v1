using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIMapTile : MonoBehaviour
{
    [SerializeField] private RawImage icon;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private TextMeshProUGUI mapNrText;
    [SerializeField] private Animator animator;
    private string nameFormat = "#{0}";
    private UIMapList mapList;
    private int mapId;
    private bool selected;
    public void Init(int mapId, Texture2D icon, UIMapList mapList)
    {
        this.mapId = mapId;
        mapNrText.text = string.Format(nameFormat,(mapId+1)); 

        icon.Apply();
        this.icon.texture = icon;
        
        this.mapList = mapList;

        highscoreText.text = HighscoreSystem.GetHighscore(mapId).ToString("N0");
    }

    public void ClickButton()
    {
        Select(true);
        mapList.UpdateSelected(mapId);
    }

    public void Select(bool selected)
    {
        if (this.selected == selected) return;
        this.selected = selected;

        if (selected) animator.SetTrigger("Select");
        else animator.SetTrigger("Deselect");
    }
}
