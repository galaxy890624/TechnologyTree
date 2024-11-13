using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 注意 Instantiate 和 Destroy 不可以寫在同一個.cs腳本裡, 否則會衝突
/// </summary>
public class DestroySkillMessageBox : MonoBehaviour
{
    public GameObject SkillMessageBox;
    public SkillClick SkillClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void HideSkillMessageBox()
    {
        Destroy(SkillMessageBox);
    }
    // Update is called once per frame
    void Update()
    {
        SkillMessageBox = SkillClick.SkillMessageBoxInstance;
    }
}
