using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "ExpTable", menuName = "Player Data/new ExpTable")]
public class ExpTable : ScriptableObject
{
    public long[] MaxExp;
}
