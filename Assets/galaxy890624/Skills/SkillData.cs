using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家的技能資料
/// </summary>
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill Data/new Skill Data")]
public class SkillData : ScriptableObject
{
    [Header("技能索引值")]
    public int SkillIndex;
    [Header("技能名稱")]
    public string SkillName;
    [Header("技能等級"), Range(0, 500)]
    public int Lv = 0;
    [Header("技能每個等級的能力值")]
    public float[] SkillValues = null;
    [Header("技能每個等級的所需等級")]
    public int[] RequireLevels = null;
    [Header("技能每個等級的所需經驗值")]
    public int[] RequireExps = null;

    // Lambda 運算子 (簡寫)
    // Lambda 符號後可以運算或寫程式

    /// <summary>
    /// 目前技能的能力值
    /// </summary>
    public float SkillValue => SkillValues[Lv - 1]; // 注意SkillValue 和 SkillValues[] 的差別
    public float RequireLevel => RequireLevels[Lv - 1];
    public float RequireExp => RequireExps[Lv - 1];

}
