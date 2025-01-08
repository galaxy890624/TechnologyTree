using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace galaxy890624
{
    /// <summary>
    /// 所有的技能列表
    /// </summary>
    public class SkillManager : MonoBehaviour
    {
        public static SkillManager Instance; // 宣告單例模式
        [Header("點擊到的技能按鈕")]
        public SkillData ActivateSkill;

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

