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
    public SkillData SkillData;
    public GameObject SkillImage; // 技能圖片
    public Transform SkillImagePosition; // 技能圖片 的位置
    public GameObject SkillMessageBox; // 技能說明 的 框框

    // Start is called before the first frame update
    void Start()
    {

    }
    /// <summary>
    /// 顯示技能說明的框框
    /// </summary>
    public void ShowSkillMessageBox()
    {
        print($"<color=#ff00ff>產生<color=#00ff00>{SkillMessageBox.name}</color>!</color>");
        Instantiate(SkillMessageBox, new Vector3(100f, 0f, 0f), Quaternion.identity, SkillImagePosition); // 產生的位置不對
    }
    /*private void OnMouseEnter()
    {
        // 捕捉滑鼠的圖片
        print($"<color=#ff00ff>滑鼠在<color=#00ff00>{gameObject.name}</color>!</color>");
        // SkillImage = this.gameObject;

        // 生成在技能圖示 右邊100px
        // Instantiate( GameObject.name<GameObject>, Vector3, Quaternion.identity, Transform )
        Instantiate(SkillMessageBox, new Vector3(100f, 0f, 0f), Quaternion.identity, SkillImagePosition);
    }
    private void OnMouseExit()
    {
        // Destroy(SkillMessageBox);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
