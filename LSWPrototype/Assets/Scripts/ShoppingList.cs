using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LWSPrototype {
	public class ShoppingList : MonoBehaviour {

		public string[] m_ListItems;

		public TMP_Text m_ItemText;
		private List<TMP_Text> m_ItemTexts;

		// Start is called before the first frame update
		void Start() {
			m_ItemTexts = new List<TMP_Text>();
			m_ItemTexts.Add(m_ItemText);
			for (int i = 0; i < m_ListItems.Length; i++) {
				if(i == 0) {
					m_ItemText.text = m_ListItems[i];
				} else {
					TMP_Text newText = Instantiate<TMP_Text>(m_ItemText);
					newText.text = m_ListItems[i];
					newText.transform.parent = m_ItemText.transform.parent;
					newText.rectTransform.localScale = Vector2.one;

					m_ItemTexts.Add(newText);
				}
			}
		}

		// Update is called once per frame
		void Update() {

		}
	}
}