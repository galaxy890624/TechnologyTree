using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataTester : MonoBehaviour
{
    public Data PlayerData;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) // 按下空格鍵測試
        {
            PlayerData.CurrentHP -= 10;
            print($"<color=#ff00ff>血量減少 <color=#00ff00>10</color>，目前血量: <color=#00ff00>{PlayerData.CurrentHP}</color></color>");
        }

        if (Input.GetKeyDown(KeyCode.R)) // 按下 R 鍵恢復血量
        {
            PlayerData.CurrentHP = PlayerData.MaxHP;
            print($"<color=#ff00ff>血量恢復至最大: <color=#00ff00>{PlayerData.CurrentHP}</color></color>");
        }
    }
}
