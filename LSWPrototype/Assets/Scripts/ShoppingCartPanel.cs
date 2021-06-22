using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {

    public class ShoppingCartPanel : MonoBehaviour {

        public CartItemBox m_ItemBox;
        private List<CartItemBox> m_Items = new List<CartItemBox>();
        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void ShowShoppingCart(ShoppingCart shoppingCart) {
            Inventory inventory = GameManager.GetInstance().GetInventory();

            for (int i = 0; i < shoppingCart.GetCount(); i++) {
                ShoppingCart.CartItem cartItem = shoppingCart.GetItemAt(i);
                Inventory.Stock stock = inventory.GetStock(cartItem.m_Item);

                if (i < m_Items.Count) {
                    m_Items[i].ShowItem(stock.m_DisplayName, cartItem.m_Count, stock.m_Price);
                } else {
                    if (i == 0) {
                        m_ItemBox.ShowItem(stock.m_DisplayName, cartItem.m_Count, stock.m_Price);
                        m_Items.Add(m_ItemBox);
                    } else {
                        CartItemBox newItem = Instantiate<CartItemBox>(m_ItemBox);
                        newItem.transform.parent = m_ItemBox.transform.parent;
                        newItem.transform.localScale = Vector3.one;
                        newItem.ShowItem(stock.m_DisplayName, cartItem.m_Count, stock.m_Price);
                        m_Items.Add(newItem);
                    }
                }
            }
            if (m_Items.Count >= shoppingCart.GetCount()) {
                if(shoppingCart.GetCount() == 0) {
                    m_ItemBox.Hide();
                }
                for (int i = shoppingCart.GetCount() + 1; i < m_Items.Count; i++) {
                    m_Items[i].Hide();
                }
            }

            gameObject.SetActive(true);
		}

		public void Hide() {
            gameObject.SetActive(false);
		}
	}
}