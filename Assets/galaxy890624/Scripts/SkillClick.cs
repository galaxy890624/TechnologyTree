using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
/// <summary>
/// 1.滑鼠移到技能圖示 顯示技能說明的框框
/// 2.點擊技能圖示後 會發生的事情
/// </summary>
public class SkillClick : MonoBehaviour //, IPointerEnterHandler // IPointerEnterHandler 必須搭配 public void OnPointerEnter(PointerEventData PointerEventData)
{
    public Transform Content;
    //public Transform SkillImagePosition; // 技能圖片 的位置
    public GameObject SkillMessageBox; // 技能說明 的 框框
    // 用來保存生成的 SkillMessageBox 的實例
    public GameObject SkillMessageBoxInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    /// <summary>
    /// 顯示技能說明的框框
    /// </summary>
    public void ShowSkillMessageBox(EventTrigger other)
    {
        // 生成在技能圖示 右邊100px
        SkillMessageBoxInstance = Instantiate(SkillMessageBox, other.gameObject.transform.position + new Vector3(100f, 0f, 0f), Quaternion.identity, Content);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
