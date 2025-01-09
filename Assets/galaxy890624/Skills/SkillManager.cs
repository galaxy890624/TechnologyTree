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

