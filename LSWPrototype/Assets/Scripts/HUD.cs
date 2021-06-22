using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {
    public class HUD : MonoBehaviour {

        public ShoppingList m_ShoppingList;
        public ContextMenu m_ContextMenu;


		// Start is called before the first frame update
		void Start() {
            m_ContextMenu.Hide();
        }

        // Update is called once per frame
        void Update() {

        }

		internal void Show() {
            gameObject.SetActive(true);
		}

		public void ShowContext(GrocerItem item) {
            m_ContextMenu.Show(item);
		}

		internal void HideContext() {
            m_ContextMenu.Hide();
        }

		internal void Hide() {
            gameObject.SetActive(false);
		}
	}
}