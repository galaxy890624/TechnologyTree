using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace galaxy890624
{
    /// <summary>
    /// 血量顯示
    /// </summary>
    public class HPUI : MonoBehaviour
    {
        // 玩家血量資料
        public Data PlayerData;
        // 當前血量
        public Image CurrentHPImage;
        // 受傷血量變化
        public Image HurtedHPImage;
        // 當前生命值 / 最大生命值 的 文字
        public TextMeshProUGUI HPText;
        // HP變化的速度
        float HPChangeSpeed = 1f;

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
            if (PlayerData != null)
            {
                print($"<color=#ff00ff>訂閱<color=#00ff00>OnHealthChanged</color>!</color>");
                // 訂閱血量變化事件
                PlayerData.OnHealthChanged += UpdateHealthUI;
                // 初始化 UI
                UpdateHealthUI(PlayerData.CurrentHP);
            }
        }

        // OnDisable is called when the object becomes disabled
        void OnDisable()
        {
            if (PlayerData != null)
            {
                // 解除訂閱事件
                PlayerData.OnHealthChanged -= UpdateHealthUI;
            }
        }

        /// <summary>
        /// 更新血量 UI
        /// </summary>
        /// <param name="NewHP">新的血量值</param>
        private void UpdateHealthUI(float NewHP)
        {
            float Rate = NewHP / PlayerData.MaxHP;
            OnHPChanged(Rate);
            HPText.text = PlayerData.HP.ToString("N0") + "/" + PlayerData.MaxHP.ToString("N0");
        }

        private void LateUpdate()
        {
            // Mathf.MoveTowards 定額定量漸變法
            // Mathf.MoveTowards (A, B, 每一幀允許的量)

            HurtedHPImage.fillAmount = Mathf.MoveTowards(HurtedHPImage.fillAmount, CurrentHPImage.fillAmount, Time.deltaTime * HPChangeSpeed);
            if (HurtedHPImage.fillAmount < CurrentHPImage.fillAmount)
            {
                HurtedHPImage.fillAmount = CurrentHPImage.fillAmount;
            }
        }
    }
}