using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody Physics = null; // player position
    [SerializeField] Animator Animator = null;

    [Header("人物的移動速度")]
    [Range(0f, 10f)]
    [SerializeField] float MoveSpeed = 2f;
    [Header("人物的加速度")]
    [SerializeField] float MoveAcceleration = 10f;
    [Header("根據參照物來決定自身移動方向")]
    [SerializeField] Transform 方向參照物 = null;
    // [Header("要求玩家面向某個方向")]
    // [SerializeField] LocalFace 玩家面向 = null;
    [SerializeField] float JumpSpeed = 6f; // 跳躍速度
    [Header("IsGround裡面 要放 水平旋轉軸的物件")]
    [SerializeField] IsGround IsGround = null; // 放水平旋轉軸

    float VelocityX = 0f; // ad
    float VelocityY = 0f; // space
    float VelocityZ = 0f; // ws

    [SerializeField] UnityEvent IsJump = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move


        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGround.Grounded)
        {
            Physics.velocity = new Vector3(Physics.velocity.x, JumpSpeed, Physics.velocity.z);
            IsJump.Invoke();
        }

        // Get keyboard input and output a direction
        float InputX = Input.GetAxisRaw("Horizontal");
        float InputZ = Input.GetAxisRaw("Vertical");

        // 讓WSAD進行漸變
        // 大約花一秒的時間將ws漸變到輸入的值
        VelocityX = Mathf.Lerp(VelocityX, InputX, Time.deltaTime * MoveAcceleration);
        VelocityZ = Mathf.Lerp(VelocityZ, InputZ, Time.deltaTime * MoveAcceleration);

        Vector3 MoveArray = new Vector3(VelocityX, 0f, VelocityZ); // 移動向量

        // 如果我有指定方向的參照物，才需要依據這個參照物來換算
        if (方向參照物 != null)
        {
            // 如果有參照物的話就將方向換算為該參照物的方向
            MoveArray = 方向參照物.TransformDirection(MoveArray);
        }
        else
        {
            // 如果沒有參照物就使用自己當作參照物來決定方向
            MoveArray = this.transform.TransformDirection(MoveArray);
        }

        // 為了不干涉物理引擎的重力作用所以將Y值改為原始的樣貌
        MoveArray.y = Physics.velocity.y;
        Physics.velocity = MoveArray;
    }
}
