using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody Physics = null; // player position
    [SerializeField] Animator Animator = null;

    float X = 0f; // ad
    float Y = 0f; // space
    float Z = 0f; // ws

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
