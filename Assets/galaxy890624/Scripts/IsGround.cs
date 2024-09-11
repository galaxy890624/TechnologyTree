using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地板檢測器
/// </summary>
public class IsGround : MonoBehaviour
{
    public bool Grounded = false; // initialize
    [SerializeField] float DetectRadius = 0.2f;
    [SerializeField] LayerMask GroundLayer; // 地板的圖層

    private void FixedUpdate()
    {
        // 用物理引擎瞬間畫一個球 並且捕捉球當中的東西
        Collider[] 範圍內的碰撞器陣列 = Physics.OverlapSphere(this.transform.position, DetectRadius, GroundLayer);
        // 如果碰撞器碰到的東西的數量不是零表示在地上
        if (範圍內的碰撞器陣列.Length > 0)
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
