using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPosition : MonoBehaviour
{
    public TextMeshProUGUI PositionText;
    
    [SerializeField, Header("ª±®a¦ì¸m")]
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PositionText.text = Player.transform.position.ToString("N3");
    }
}
