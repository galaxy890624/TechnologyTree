using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{

    [SerializeField] Rigidbody Physics = null; // player position
    [Header("�H�������ʳt��")]
    [Range(0f, 10f)]
    [SerializeField] float MoveSpeed = 2f;
    [Header("�H�����[�t��")]
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

        // ��WSAD�i�溥��
        // �j����@���ɶ��Nws���ܨ��J����
        VelocityX = Mathf.Lerp(VelocityX, InputX, Time.deltaTime * MoveAcceleration);
        VelocityZ = Mathf.Lerp(VelocityZ, InputZ, Time.deltaTime * MoveAcceleration);

        Vector3 MoveArray = new Vector3(VelocityX, 0f, VelocityZ); // ���ʦV�q
        Physics.velocity = MoveArray;

    }
}
