using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 點擊技能圖示後 會發生的事情
/// </summary>
public class SkillClick : MonoBehaviour
{
    SkillData SkillData;
    GameObject SkillImage;
    GameObject SkillMessageBox; // 技能說明的框框
    Transform SkillMessageBoxPosition; // 技能說明的框框位置

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseEnter()
    {
        Instantiate(SkillMessageBox);
    }
    private void OnMouseExit()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
