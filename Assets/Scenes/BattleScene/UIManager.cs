using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    List<TextUI> TEST1 = new List<TextUI>();

    public Dictionary<TextClass, TextMeshProUGUI> TEXTDICT1 = new Dictionary<TextClass, TextMeshProUGUI>();

    public void Init()
    {
        foreach (TextUI textUI in TEST1)
        {
            TEXTDICT1.Add(textUI.textClass, textUI.tmpGUI);
        }
    }
}

[System.Serializable]
public struct TextUI
{
    public TextMeshProUGUI tmpGUI;
    public TextClass textClass;
}

public enum TextClass
{
    
}