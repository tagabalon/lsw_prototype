using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace LWSPrototype {
    public class ContextButton : MonoBehaviour {
        public TMP_Text m_Key;
        public TMP_Text m_Label;

        public KeyCode m_KeyCode;

        [System.Serializable]
        public class ContextAction : UnityEvent<ContextButton> { }
        public ContextAction m_OnKeyPress;


        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
			if (Input.GetKeyUp(m_KeyCode)) {
                m_OnKeyPress.Invoke(this);
			}
        }
    }
}