using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace galaxy890624
{
    /// <summary>
    /// 血量顯示
    /// </summary>
    public class HPUI : MonoBehaviour
    {
        // 當前血量
        public Image CurrentHPImage;
        // 受傷血量變化
        public Image HurtedHPImage;

        /// <summary>
        /// 血量變化
        /// </summary>
        /// <param name="Rate">Rate = Current / Max> </param>
        public void OnHPChanged(float Rate)
        {
            CurrentHPImage.fillAmount = Rate;
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}