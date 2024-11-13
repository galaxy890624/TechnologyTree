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
        /// 可以解鎖技能了
        /// </summary>
        void CanUnlockSkill()
        {
            // 符合全部的條件 才可以解鎖技能
            while ( Data.Level >= SkillData.RequireLevel && Data.Exp >= SkillData.RequireExp )
            {
                // animation
            }

        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
