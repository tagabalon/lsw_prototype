using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LWSPrototype {
    public class HUD : MonoBehaviour {

        public ShoppingList m_ShoppingList;
        public ContextMenu m_ContextMenu;
		public TMP_Text m_Timer;

		private int m_MaxTime;
		private float m_CurrentTime;

		// Start is called before the first frame update
		void Start() {
            m_ContextMenu.Hide();
        }

        // Update is called once per frame
        void Update() {

			m_CurrentTime -= Time.deltaTime;

			int _time = Mathf.RoundToInt(m_CurrentTime);
			string minutes = Mathf.Floor(_time / 60).ToString("00");
			string seconds = (_time % 60).ToString("00");
			m_Timer.text = minutes + ":" + seconds;


		}

		internal void Show(ShoppingList.Item[] items = null, int timeLimit = 0) {
			if(items != null) {
				m_ShoppingList.ShowList(items);
			}
			m_MaxTime = timeLimit;
			m_CurrentTime = timeLimit;

			string minutes = Mathf.Floor(m_CurrentTime / 60).ToString("00");
			string seconds = (m_CurrentTime % 60).ToString("00");
			m_Timer.text = minutes + ":" + seconds;

			//else {
			//	m_ShoppingList.Hide();
			//}

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

		internal void ShowContext(TillMachine tillMachine) {
			m_ContextMenu.Show(tillMachine);
		}
	}
}