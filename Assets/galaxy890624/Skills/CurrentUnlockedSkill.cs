using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可以解鎖的技能
/// </summary>
[CreateAssetMenu(fileName = "CurrentUnlockedSkill", menuName = "Skill Data/new CurrentUnlockedSkill")]
public class CurrentUnlockedSkill : ScriptableObject
{
    [Header("CurrentUnlockedSkill")] // 目前可以升級的技能
    public SkillData[] CanUnlockedSkill;
    
    public TreeNode[] UnlockedTreeNode;
}
