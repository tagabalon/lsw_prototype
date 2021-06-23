using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {
    public class GrocerItem : MonoBehaviour {

        [SerializeField]
        private GrocerItems.ItemType m_ItemType;

        [SerializeField]
        private string m_DisplayName;

        [SerializeField]
        private float m_SellingPrice;

        [SerializeField]
        private int m_Count = 20;

		public string DisplayName {
            get {
                return m_DisplayName;
            }
            internal set {
                m_DisplayName = value;
			}
        }

		public float SellingPrice {
            get {
                return m_SellingPrice;
            }
            internal set {
                m_SellingPrice = value;
			}
        }

		public GrocerItems.ItemType ItemType {
            get {
                return m_ItemType;
            }
            internal set {
                m_ItemType = value;
            }
        }

		// Start is called before the first frame update
		void Start() {
            Inventory inventory = GameManager.GetInstance().GetInventory();
            m_DisplayName = inventory.GetStock(m_ItemType).m_DisplayName;
            m_SellingPrice = inventory.GetStock(m_ItemType).m_Price;
        }

        // Update is called once per frame
        void Update() {

        }

	}
}