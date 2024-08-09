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
        if (other.gameObject.name == "Player")
        {
            Data.Exp += GetAward.GetExp;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
