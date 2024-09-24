using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LvUI : MonoBehaviour
{
    public TextMeshProUGUI LvText;
    public TextMeshProUGUI ExpText;
    public Data Data; // ScriptableObject

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LvText.text = " Lv = " + Data.Level.ToString("N0");
        ExpText.text = " Exp = " + Data.Exp.ToString("N0") + " / " + Data.MaxExp.ToString("N0");
    }
}
