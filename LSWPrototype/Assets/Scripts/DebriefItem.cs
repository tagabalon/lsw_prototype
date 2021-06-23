using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace LWSPrototype {
    public class DebriefItem : MonoBehaviour {
        public TMP_Text m_ItemName;
        public TMP_Text m_Count;
        public TMP_Text m_Score;

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

		internal void Show(string itemName, string itemCount, int score) {
            m_ItemName.text = itemName;
            m_Count.text = itemCount;
            m_Score.text = score.ToString();

            gameObject.SetActive(true);
		}
	}
}