using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechnologyTreeUI : Windows<TechnologyTreeUI>
{
    protected override void Update()
    {
        base.Update(); // 先讓Windows底層做事
        if (Input.GetKeyDown(KeyCode.Tab)) // Press "Tab" key to open "TechnologyTreeUI"
        {
            if (isOpen)
            {
                Close();
                // 遊戲中鎖定滑鼠
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
            else
            {
                Open();
                // 解除鎖定滑鼠
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.001f;
            }
        }

    }
}
