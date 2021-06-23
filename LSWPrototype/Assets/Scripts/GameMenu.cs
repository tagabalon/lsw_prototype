using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace LWSPrototype {
    public class GameMenu : MonoBehaviour {
        private static GameMenu m_Instance;

        public HUD m_Hud;
        public ShoppingCartPanel m_Cart;
        public ShoppingList m_BriefingList;
        public Image m_BriefingPanel;
        public PlayerCharacter m_Player;
        private int m_TimeLimit;
        public TMP_Text m_Time;
        public DebriefPanel m_DebriefPanel;
        public Image m_GameOverPanel;
        private void Awake() {
            m_Instance = this;
        }

		internal void ShowGameOver() {
            m_Hud.Hide();
            m_GameOverPanel.gameObject.SetActive(true);

            m_Player.Disable();
        }

		// Start is called before the first frame update
		void Start() {
            m_Hud.Show();
            m_Cart.Hide();
            m_DebriefPanel.Hide();
            m_GameOverPanel.gameObject.SetActive(false);
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

		internal void Show() {
            gameObject.SetActive(true);
		}

		internal void ShowBriefing(ShoppingList.Item[] shoppingList, int time) {
            m_GameOverPanel.gameObject.SetActive(false);
            m_Player.SetList(shoppingList);
            m_BriefingList.ShowList(shoppingList);
            m_TimeLimit = time;
            m_Hud.Hide();

            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            m_Time.text = minutes + ":" + seconds;

            m_BriefingPanel.gameObject.SetActive(true);
        }

		public void CloseCart() {
            m_Hud.Show();
            m_Cart.Hide();
		}

		internal void ShowContext(TillMachine tillMachine) {
            m_Hud.ShowContext(tillMachine);
        }

		internal void ShowDebriefing(ShoppingCart shoppingCart) {
            int remainingTime = m_Hud.GetRemainingTime();

            m_DebriefPanel.ShowDebrief(m_Player.GetList(), shoppingCart, remainingTime);

            m_Player.Disable();
		}

		internal void HideHUD() {
            m_Hud.Hide();
		}

        public int GetRemainingTime() {
            return m_Hud.GetRemainingTime();
		}

		public void CloseBriefing() {
            m_BriefingPanel.gameObject.SetActive(false);
            m_Hud.Show(m_Player.GetList(), m_TimeLimit); ;
            m_Player.Enable();
        }
	}
}