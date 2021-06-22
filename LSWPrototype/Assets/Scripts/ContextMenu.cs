using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace LWSPrototype {
    public class ContextMenu : MonoBehaviour {
        public TMP_Text m_Label;
        public TMP_Text m_PriceText;
        private GrocerItem m_Item;

        public ContextButton m_Pickup;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            if(m_Item != null) {

                Vector3 pos = Camera.main.WorldToScreenPoint(m_Item.transform.position);
                gameObject.transform.position = pos;
            }
        }

		internal void Hide() {
            gameObject.SetActive(false);
            m_Item = null;

        }

		internal void Show(GrocerItem item) {
            m_Label.text = item.DisplayName;
            m_PriceText.text = item.SellingPrice.ToString();
            m_Item = item;
            gameObject.SetActive(true);
		}

        public void ContextAction(ContextButton button) {
            if(button == m_Pickup) {

                GameManager.GetInstance().AddToCart(m_Item);
			}
        }
    }
}