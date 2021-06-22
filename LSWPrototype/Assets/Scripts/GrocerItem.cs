using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {
    public class GrocerItem : MonoBehaviour {

        [SerializeField]
        private string m_DisplayName;

		public string DisplayName {
            get {
                return m_DisplayName;
            }
            internal set {
                m_DisplayName = value;
			}
        }

		// Start is called before the first frame update
		void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

	}
}