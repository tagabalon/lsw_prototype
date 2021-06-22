using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {
    public class HUD : MonoBehaviour {
        private static HUD m_Instance;

        public ShoppingList m_ShoppingList;
        public ContextMenu m_ContextMenu;

		private void Awake() {
            m_Instance = this;
		}

		// Start is called before the first frame update
		void Start() {
            m_ContextMenu.Hide();
        }

        // Update is called once per frame
        void Update() {

        }

        public static HUD GetInstance() {
            return m_Instance;
		}

        public void ShowContext(GrocerItem item) {
            m_ContextMenu.Show(item);
		}

		internal void HideContext() {
            m_ContextMenu.Hide();
        }
	}
}