using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Object Data", menuName = "Object Data/new Award Data")]
public class GetAward : ScriptableObject
{
    [Header("獲得經驗值")]
    public float GetExp = 0;
}
