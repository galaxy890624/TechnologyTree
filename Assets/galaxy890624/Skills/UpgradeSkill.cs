﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public SkillData[] SkillDataList;
        public TreeNode[] TreeNodeList; 
        public Data Data;
        /// <summary>
        /// CurrentUnlockedSkill
        /// 1.public SkillData[] CanUnlockedSkill;
        /// 2.public TreeNode[] UnlockedTreeNode;
        /// </summary>
        public CurrentUnlockedSkill CurrentUnlockedSkill;

        // Initialize
        private void Awake()
        {
            // 一開始解鎖0號技能
            CurrentUnlockedSkill.CanUnlockedSkill.Append<ScriptableObject>(SkillDataList[0]);
        }
        // Start is called before the first frame update
        void Start()
        {
            
        }
        /// <summary>
        /// 可被解鎖的技能
        /// </summary>
        public void CanUnlockSkill() // 搭配Button
        {
            // 符合全部的條件 才可以解鎖技能
            if ( Data.Level >= SkillData.RequireLevel && Data.Exp >= SkillData.RequireExp )
            {
                // 技能升級
                SkillData.Lv++;
                
                // animation
                // sound

            }
            else
            {
                print("<color=#ff00ff>還沒辦法升級!</color>");
            }
        }
        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
