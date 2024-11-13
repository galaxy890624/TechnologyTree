using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySkillMessageBox : MonoBehaviour
{
    public GameObject SkillMessageBox;
    public SkillClick SkillClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void HideSkillMessageBox()
    {
        Destroy(SkillMessageBox);
    }
    // Update is called once per frame
    void Update()
    {
        SkillMessageBox = SkillClick.SkillMessageBoxInstance;
    }
}
