using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace LWSPrototype {
	public class ShoppingList : MonoBehaviour {


		public class Item {
			public GrocerItems.ItemType item;
			public int count;
		}

		//public string[] m_ListItems;

		public TMP_Text m_ItemText;
		private List<TMP_Text> m_ItemTexts;

		// Start is called before the first frame update
		void Start() {
			
		}

		// Update is called once per frame
		void Update() {

		}

		internal void ShowList(Item[] shoppingList) {
			Inventory inventory = GameManager.GetInstance().GetInventory();

			m_ItemTexts = new List<TMP_Text>();
			m_ItemTexts.Add(m_ItemText);
			for (int i = 0; i < shoppingList.Length; i++) {
				ShoppingList.Item listItem = shoppingList[i];

				string itemName = inventory.GetStock(listItem.item).m_DisplayName + " x" + listItem.count;

				if (i == 0) {
					m_ItemText.text = itemName;
				} else {
					TMP_Text newText = Instantiate<TMP_Text>(m_ItemText);
					newText.text = itemName;
					newText.transform.parent = m_ItemText.transform.parent;
					newText.rectTransform.localScale = Vector2.one;

					m_ItemTexts.Add(newText);
				}
			}

			gameObject.SetActive(true);
		}

		internal void Hide() {
			gameObject.SetActive(false);
		}
	}
}