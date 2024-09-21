using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{

    [SerializeField] Rigidbody Physics = null; // player position
    [Header("人物的移動速度")]
    [Range(0f, 10f)]
    [SerializeField] float MoveSpeed = 2f;
    [Header("人物的加速度")]
    [SerializeField] float MoveAcceleration = 10f;

    float VelocityX = 0f; // ad
    // float VelocityY = 0f; // space
    float VelocityZ = 0f; // ws

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get keyboard input and output a direction
        float InputX = Input.GetAxisRaw("Horizontal");
        float InputZ = Input.GetAxisRaw("Vertical");

        // 讓WSAD進行漸變
        // 大約花一秒的時間將ws漸變到輸入的值
        VelocityX = Mathf.Lerp(VelocityX, InputX, Time.deltaTime * MoveAcceleration);
        VelocityZ = Mathf.Lerp(VelocityZ, InputZ, Time.deltaTime * MoveAcceleration);

        Vector3 MoveArray = new Vector3(VelocityX, 0f, VelocityZ); // 移動向量
        Physics.velocity = MoveArray;

    }
}
