using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace galaxy890624
{
    /// <summary>
    /// 所有的技能列表
    /// </summary>
    public class SkillManager : MonoBehaviour
    {
        public static SkillManager Instance; // 宣告單例模式 Singleton pattern
        [Header("點擊到的技能按鈕")]
        public SkillData ActivateSkill; // Mouse Information

        [Header("UI")]
        public Image SkillImage;
        public TextMeshProUGUI SkillNameText; // 技能名稱文字
        public TextMeshProUGUI SkillInfoText; // 技能資訊文字

        public SkillButton[] SkillButtons;

        [Header("PlayerData")]
        public Data Data;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                if (Instance != this)
                {
                    Destroy(gameObject);
                }
            }
            DontDestroyOnLoad(gameObject);
        }
        public void UpgradeButton()
        {
            // 如果什麼按鈕都不點,就直接按下升級按鈕,會回傳錯誤訊息
            if (ActivateSkill == null)
            {
                return; // 不做任何事
            }

            // 解鎖條件
            if (Data.Level >= ActivateSkill.RequireLevel && Data.Exp >= ActivateSkill.CostExp && ActivateSkill.PreSkills.Length == 0)
            {
                // 把顏色改回亮的顏色(白色)
                SkillButtons[ActivateSkill.SkillIndex].GetComponent<UnityEngine.UI.Image>().color = Color.white;
                // 扣除 對應的經驗
                Data.Exp -= ActivateSkill.CostExp;
                // 更新技能資訊
                DisplaySkillInfo();
                // 完成解鎖
                ActivateSkill.IsUnlocked = true;
            }
        }
        public void DisplaySkillInfo()
        {
            // SkillImage.sprite = ActivateSkill.skillSprite;
            SkillNameText.text = ActivateSkill.SkillName;
            SkillInfoText.text = ActivateSkill.SkillInfo;
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

