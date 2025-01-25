using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
/// <summary>
/// 玩家資料
/// fillName 新創建的檔案名稱
/// menuName 右鍵的目錄名稱
/// </summary>
[CreateAssetMenu(fileName = "Data", menuName = "Player Data/new Player Data")]
public class Data : ScriptableObject
{
    [Header("玩家等級")]
    public int Level;
    [Header("玩家經驗值")]
    public float Exp;
    [Header("升到下個等級的經驗值")]
    public float MaxExp = 0;
    [Header("玩家當前血量")]
    public float HP; // 不要直接修改, 否則無法處理刷新事件
    [Header("玩家最大血量")]
    public float MaxHP;

    /// <summary>
    /// 當血量改變時觸發的事件
    /// </summary>
    public event Action<float> OnHealthChanged;

    /// <summary>
    /// 玩家當前血量，帶有通知功能
    /// </summary>
    public float CurrentHP
    {
        get => HP;
        set
        {
            float NewHP = Mathf.Clamp(value, 0, MaxHP);
            if (HP != NewHP)
            {
                Debug.Log($"<color=#ff00ff>HP改變 = <color=#00ff00>{NewHP}</color></color>");
                HP = NewHP;
                OnHealthChanged?.Invoke(HP); // 觸發事件
            }
        }
    }

    /// <summary>
    /// 初始化資料
    /// </summary>
    public void Initialize(float initialHP, float maxHP)
    {
        MaxHP = maxHP;
        CurrentHP = initialHP;
    }
}
