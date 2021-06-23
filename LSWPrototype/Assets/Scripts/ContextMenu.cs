using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace LWSPrototype {
    public class ContextMenu : MonoBehaviour {
        public Image m_PriceTag;
        public Image m_LabelBox;

        public TMP_Text m_ItemName;
        public TMP_Text m_Label;
        public TMP_Text m_PriceText;
        private GrocerItem m_Item;

        public ContextButton m_Pickup;
        public ContextButton m_Buy;

        private Transform m_Target;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if(m_Target != null) {

                Vector3 pos = Camera.main.WorldToScreenPoint(m_Target.position);
                gameObject.transform.position = pos;
            }
        }

		internal void Hide() {
            gameObject.SetActive(false);
            m_Item = null;
            m_Target = null;
        }

		internal void Show(GrocerItem item) {
            m_ItemName.text = item.DisplayName;
            m_PriceText.text = item.SellingPrice.ToString("0.00");
            m_Item = item;
            m_Target = m_Item.transform;

            m_PriceTag.gameObject.SetActive(true);
            m_LabelBox.gameObject.SetActive(false);

            m_Pickup.Show();
            m_Buy.Hide();
            gameObject.SetActive(true);
		}

		internal void Show(TillMachine tillMachine) {
            m_Label.text = "Check out";
            m_LabelBox.gameObject.SetActive(false);
            m_PriceTag.gameObject.SetActive(false);

            m_Target = tillMachine.transform;
            m_Pickup.Hide();
            m_Buy.Show();
            gameObject.SetActive(true);
        }

		public void ContextAction(ContextButton button) {
            if(button == m_Pickup) {

                GameManager.GetInstance().AddToCart(m_Item);
			}else if(button == m_Buy) {

                GameManager.GetInstance().Checkout();
			}
        }
    }
}