using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1.技能解鎖
/// 2.SkillIndex的數字用廣度優先的層序
/// </summary>
[CreateAssetMenu(fileName = "TreeNode", menuName = "Skill Data/new TreeNode")]
public class TreeNode : ScriptableObject
{
    [Header("Current Skill Index")]
    public int SkillIndex; // Current Skill Index
    public SkillData SkillData;
    public SkillData[] UnlockSkill;
}
