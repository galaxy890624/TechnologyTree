using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using Unity.VisualScripting;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI SpdText; // 玩家的速度

    [SerializeField, Header("玩家物件")]
    GameObject Player;
    public ThirdPersonController ThirdPersonController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SpdText.text = " Spd = " + Player.GetComponent<ThirdPersonController>().MoveSpeed.ToString("N3");
    }
}
