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
    [SerializeField] IsGround IsGround = null;

    float X = 0f; // ad
    float Y = 0f; // space
    float Z = 0f; // ws

    [SerializeField] UnityEvent IsJump = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
