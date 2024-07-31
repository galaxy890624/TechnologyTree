using AYE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>�M���Ψ��X�RScrollPage�\��A�Ϩ䦨�����\�O�@���ת����ӫǾԪ������C</summary>
public class ScrollPageWidthSupport : MonoBehaviour
{
    private void Reset()
    {
        scrollPage = this.GetComponent<ScrollPage>();
    }

    [SerializeField] ScrollPage scrollPage = null;
    [SerializeField][Header("�ݭn�����Y��")] Canvas canvas = null;
    [SerializeField][Header("�����Y��Ϊ�Content")] RectTransform content = null;
    [SerializeField][Header("�v�T������")] RectTransform[] pages = new RectTransform[0];

    float lastWidth = 0f;
    float lastCanvasScaleFactor = 0f;
    private void LateUpdate()
    {
        if (lastWidth != Screen.width || lastCanvasScaleFactor != canvas.scaleFactor)
        {
            lastWidth = Screen.width;
            lastCanvasScaleFactor = canvas.scaleFactor;
            UpdateUI();
        }
    }
    [SerializeField][Header("����LOG")] bool showLog = false;
    void UpdateUI()
    {
        float w = Screen.width / canvas.scaleFactor;
        content.sizeDelta = new Vector2(w * (float)scrollPage.totalNumberOfPages, content.sizeDelta.y);
        for(int i = 0; i < pages.Length; i++)
        {
            pages[i].sizeDelta = new Vector2(w, pages[i].sizeDelta.y);
            pages[i].anchoredPosition = new Vector2((float)i * w, pages[i].anchoredPosition.y);
        }
        if (showLog)
            Debug.Log("���]�ؤo");
    }
}
