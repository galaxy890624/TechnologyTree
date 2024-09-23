using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public Data Data;
    public ExpTable ExpTable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Data.MaxExp = ExpTable.MaxExp[Data.Level];
        if (Data.Exp >= ExpTable.MaxExp[Data.Level])
        {
            Data.Exp -= ExpTable.MaxExp[Data.Level];
            Data.Level += 1;
        }
    }
}
