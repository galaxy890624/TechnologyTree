using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetExp : MonoBehaviour
{
    Data Data;
    GetAward GetAward;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        print($"<color=#ff00ff><color=#00ff00>{this.gameObject.name}</color>碰到了<color=#00ff00>{other.gameObject.name}</color>唷!</color>");
        if (other.gameObject.name == "RobotKyle")
        {
            Data.Exp += GetAward.GetExp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
