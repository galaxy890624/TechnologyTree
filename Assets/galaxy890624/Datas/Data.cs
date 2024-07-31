using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Player Data/new Player Data")]
public class Data : ScriptableObject
{
    public float Level = 0;
    public float Exp = 0;
    public float MaxExp= 0;
}
