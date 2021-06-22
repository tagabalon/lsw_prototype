using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {
    public class ShoppingCart {

        public class CartItem {
            public GrocerItems.ItemType m_Item;
            public int m_Count;

			public CartItem(GrocerItems.ItemType itemType, int count) {
                m_Item = itemType;
                m_Count = count;
			}
		}

        private List<CartItem> m_Items;

        public ShoppingCart() {
            m_Items = new List<CartItem>();
		}

        public void AddItem(GrocerItem item) {
            CartItem cartItem = GetItem(item.ItemType);

            if(cartItem == null) {
                cartItem = new CartItem(item.ItemType, 1);
                m_Items.Add(cartItem);
			} else {
                cartItem.m_Count++;
			}
		}

		private CartItem GetItem(GrocerItems.ItemType itemType) {
			for(int i = 0; i < m_Items.Count; i++) {
                if (m_Items[i].m_Item == itemType)
                    return m_Items[i];
			}
            return null;
		}
	}
}