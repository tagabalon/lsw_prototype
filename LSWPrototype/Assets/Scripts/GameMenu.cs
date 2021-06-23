using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LWSPrototype {
    public class GameMenu : MonoBehaviour {
        private static GameMenu m_Instance;

        public HUD m_Hud;
        public ShoppingCartPanel m_Cart;

        private void Awake() {
            m_Instance = this;
        }
        // Start is called before the first frame update
        void Start() {
            m_Hud.Show();
            m_Cart.Hide();
        }

        // Update is called once per frame
        void Update() {

        }
        public static GameMenu GetInstance() {
            return m_Instance;
        }

		internal void ShowContext(GrocerItem activeItem) {
            m_Hud.ShowContext(activeItem);

        }

		internal void HideContext() {
            m_Hud.HideContext();
        }
        public void OpenCart(ContextButton button) {
            m_Hud.Hide();
            m_Cart.ShowShoppingCart(GameManager.GetInstance().m_ShoppingCart);
        }

        public void CloseCart() {
            m_Hud.Show();
            m_Cart.Hide();
		}

		internal void ShowContext(TillMachine tillMachine) {
            m_Hud.ShowContext(tillMachine);
        }
	}
}