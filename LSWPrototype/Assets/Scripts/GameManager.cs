using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LWSPrototype {
    public class GameManager : MonoBehaviour {
        private static GameManager m_Instance;

		public ShoppingCart m_ShoppingCart;
		private void Awake() {
            m_Instance = this;

			m_ShoppingCart = new ShoppingCart();
		}

		// Start is called before the first frame update
		void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public static GameManager GetInstance() {
            return m_Instance;
		}

		public void AddToCart(GrocerItem item) {
			m_ShoppingCart.AddItem(item);
		}

		public Inventory GetInventory() {
			return GetComponent<Inventory>();
		}
	}

}