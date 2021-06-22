using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace LWSPrototype {
    public class ContextMenu : MonoBehaviour {
        public TMP_Text m_Label;
        private GrocerItem m_Item;

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
            m_Item = item;
            gameObject.SetActive(true);
		}
	}
}