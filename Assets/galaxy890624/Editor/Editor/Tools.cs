using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.Mathematics;

public class Tools : MonoBehaviour
{
    [MenuItem("�u��/�M���Ҧ����")]
    static public void �M�����()
    {
        // �����Ҧ�����o�ӹC�������
        PlayerPrefs.DeleteAll();
        // �n�DUnity�ߨ谵��, �קK�b�C��������ɤ�����(�O��,...)
        PlayerPrefs.Save();
    }
    [MenuItem("�u��/�K�[100M�_��")]
    static public void �[100M�_��()
    {
        SaveManager.instance.gem += 100000000;
    }

    [MenuItem("�u��/�ߨ���z")]
    static public void �ߨ���z()
    {
        //�p�G�O�b�����, �~�i�H�������a

        if (Application.isPlaying)
        SaveManager.instance.hp -= float.MaxValue;
    }
}