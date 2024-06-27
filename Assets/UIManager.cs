using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class uiManager : MonoBehaviour
{
    public TextMeshProUGUI LeftPlayer;
    public TextMeshProUGUI RightPlayer;
    public void SetLeftPlayerScoreText(string text)
    {
        LeftPlayer.SetText(text);
    }
    public void SetRightPlayerScoreText(string text)
    {
        RightPlayer.SetText(text);
    }
    
    
}