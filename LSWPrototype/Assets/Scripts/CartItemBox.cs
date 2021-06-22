using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace LWSPrototype {
    public class CartItemBox : MonoBehaviour {
        public TMP_Text m_DisplayName;
        public TMP_Text m_Count;
        public TMP_Text m_Price;
        public TMP_Text m_TotalPrice;
        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

		internal void ShowItem(string displayName, int count, float price) {
            m_DisplayName.text = displayName;
            m_Count.text = "x" + count.ToString();
            m_Price.text = price.ToString("#.##");

            float total = count * price;
            m_TotalPrice.text = total.ToString("#.##");

            gameObject.SetActive(true);

        }

		internal void Hide() {
            gameObject.SetActive(false);
		}
	}
}