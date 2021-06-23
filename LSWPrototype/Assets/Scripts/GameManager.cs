using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LWSPrototype {
    public class GameManager : MonoBehaviour {
        private static GameManager m_Instance;
		public PlayerCharacter m_Player;
		public Canvas m_MainMenu;
		public GameMenu m_GameMenu;


		public ShoppingCart m_ShoppingCart;
		private void Awake() {
            m_Instance = this;

			m_ShoppingCart = new ShoppingCart();
			m_Player.Disable();

			m_MainMenu.gameObject.SetActive(true);
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

		public void StartGame() {
			m_MainMenu.gameObject.SetActive(false);
			ShoppingList.Item[] shoppingList = GenerateList();

			int time = 30;
			if(shoppingList.Length > 5) {
				time += (5 * (shoppingList.Length - 5));
			}

			m_GameMenu.ShowBriefing(shoppingList, time);
			//m_Player.Enable();
		}

		public void ExitGame() {
			Application.Quit();
		}

		private ShoppingList.Item[] GenerateList() {

			int count = 3 + UnityEngine.Random.Range(1, 5);

			List<ShoppingList.Item> items = new List<ShoppingList.Item>();

			List<GrocerItems.ItemType> itemList = new List<GrocerItems.ItemType>((IEnumerable<GrocerItems.ItemType>)Enum.GetValues(typeof(GrocerItems.ItemType)));

			for(int i = 0; i < count; i++) {
				ShoppingList.Item item = new ShoppingList.Item();

				int k = UnityEngine.Random.Range(0, 100) % itemList.Count;
				item.item = itemList[k];
				itemList.RemoveAt(k);

				int amount = UnityEngine.Random.Range(1, 10);
				item.count = amount;

				items.Add(item);
			}

			return items.ToArray();
		}

		internal void Checkout() {
			
		}
	}

}