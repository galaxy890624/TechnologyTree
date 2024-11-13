using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace galaxy890624
{
    /// <summary>
    /// Upgrade Skill System
    /// </summary>
    public class UpgradeSkill : MonoBehaviour
    {
        public SkillData SkillData;
        public TreeNode TreeNode;
        public Data Data;

        // Start is called before the first frame update
        void Start()
        {
            
        }
        /// <summary>
        /// 解鎖技能之後 發生的事情
        /// 1.技能等級升級
        /// 2.解鎖 TreeNode.UnlockSkill<Array>
        /// </summary>
        void CanUnlockSkill()
        {
            // 符合全部的條件 才可以解鎖技能
            if ( Data.Level >= SkillData.RequireLevel && Data.Exp >= SkillData.RequireExp )
            {
                SkillData.Lv++;
                // animation
                // sound
            }

        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
