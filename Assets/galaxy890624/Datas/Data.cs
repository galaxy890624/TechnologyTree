using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "Player Data/new Player Data")]
public class Data : ScriptableObject
{
    public long Level = 0;
    public long Exp = 0;
    public long MaxExp= 0;
}
