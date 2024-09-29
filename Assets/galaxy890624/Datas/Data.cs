using System.Collections;
using System.Collections.Generic;
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
    public int Level = 0;
    [Header("玩家經驗值")]
    public float Exp = 0;
    [Header("升到下個等級的經驗值")]
    public float MaxExp= 0;
}
