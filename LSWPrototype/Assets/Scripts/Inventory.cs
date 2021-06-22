using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LWSPrototype {
    public class Inventory : MonoBehaviour {

        [System.Serializable]
        public class Stock {
            public GrocerItems.ItemType m_Item;
            public string m_DisplayName;
            public int m_StockCount;
            public float m_Price;
		}

        public Stock[] m_Inventory;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

		internal Stock GetStock(GrocerItems.ItemType item) {
			for(int i = 0; i < m_Inventory.Length; i++) {
                if (m_Inventory[i].m_Item == item)
                    return m_Inventory[i];
			}
            return null;
		}
	}
}