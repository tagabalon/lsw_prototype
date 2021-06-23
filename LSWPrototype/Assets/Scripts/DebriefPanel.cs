using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace LWSPrototype {
    public class DebriefPanel : MonoBehaviour {

        public DebriefItem m_ItemBox;
        private List<DebriefItem> m_Items = new List<DebriefItem>();
        public TMP_Text m_TotalScore;
        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        public void ShowDebrief(ShoppingList.Item[] shoppingList, ShoppingCart shoppingCart, int remainingTime) {
            Inventory inventory = GameManager.GetInstance().GetInventory();
            List<ShoppingCart.CartItem> cartItems =  new List<ShoppingCart.CartItem>(shoppingCart.GetItems());
            int totalScore = 0;
            for(int i = 0; i < shoppingList.Length; i++) {
                string itemName = inventory.GetStock(shoppingList[i].item).m_DisplayName;
                int purchased = 0;

                int k = -1;
                for(int j = 0; j < cartItems.Count; j++) {
                    if(cartItems[j].m_Item == shoppingList[i].item) {
                        purchased = cartItems[j].m_Count;
                        k = j;
                        break;
					}
				}
                if (k >= 0 && k < cartItems.Count)
                    cartItems.RemoveAt(k);

                string itemCount = "" + purchased + "/" + shoppingList[i].count;

                int score = 0;
                if(purchased == shoppingList[i].count) {
                    score = 2 * purchased;
				} else {
                    score = 2 * purchased;

                    score -= Mathf.Abs(purchased - shoppingList[i].count) * 5;
                }
                totalScore += score;
                if (i == 0) {
                    m_ItemBox.Show(itemName, itemCount, score);
                    m_Items.Add(m_ItemBox);
				} else {
                    DebriefItem debriefItem = Instantiate<DebriefItem>(m_ItemBox);
                    debriefItem.Show(itemName, itemCount, score);
                    m_Items.Add(debriefItem);

                    debriefItem.transform.SetParent(m_ItemBox.transform.parent);
                    debriefItem.GetComponent<RectTransform>().localScale = Vector3.one;
                }
            }
            for(int i = 0; i < cartItems.Count; i++) {

                string itemName = inventory.GetStock(cartItems[i].m_Item).m_DisplayName;
                int purchased = cartItems[i].m_Count;
                int score = cartItems[i].m_Count * -5;
                string itemCount = "" + purchased + "/0";

                totalScore += score;

                if (i == 0) {
                    m_ItemBox.Show(itemName, itemCount, score);
                    m_Items.Add(m_ItemBox);
                } else {
                    DebriefItem debriefItem = Instantiate<DebriefItem>(m_ItemBox);
                    debriefItem.Show(itemName, itemCount, score);
                    m_Items.Add(debriefItem);

                    debriefItem.transform.SetParent(m_ItemBox.transform.parent);
                    debriefItem.GetComponent<RectTransform>().localScale = Vector3.one;
                }
            }

            DebriefItem bonusScore = Instantiate<DebriefItem>(m_ItemBox);
            string minutes = Mathf.Floor(remainingTime / 60).ToString("00");
            string seconds = (remainingTime % 60).ToString("00");

            int bonScore = remainingTime * 5;
            totalScore += bonScore;

            bonusScore.Show("Remaining Time", minutes + ":" + seconds, bonScore);
            m_Items.Add(bonusScore);
            bonusScore.transform.SetParent(m_ItemBox.transform.parent);
            bonusScore.GetComponent<RectTransform>().localScale = Vector3.one;

            m_TotalScore.text = totalScore.ToString();

            gameObject.SetActive(true);
        }

		internal void Hide() {
            gameObject.SetActive(false);
		}
	}
}