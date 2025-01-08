﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 玩家的技能資料
/// </summary>
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill Data/new Skill Data")]
public class SkillData : ScriptableObject
{
    // 技能基本資料
    [Header("技能索引值")]
    public int SkillIndex;
    [Header("技能的顯示圖片")]
    Sprite SkillSprite;
    [Header("技能名稱")]
    public string SkillName;
    [Header("技能等級"), Range(0, 500)]
    public int SkillLevel = 0;
    [Header("技能的能力值")]
    public float SkillValue = 0;
    [Header("技能的描述")]
    [TextArea] // 可換行
    public string SkillInfo;
    [Header("是否被解鎖")]
    public bool IsUnlocked;
    [Header("解鎖的條件")]
    public SkillData[] PreSkills;
}
