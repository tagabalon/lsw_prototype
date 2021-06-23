using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {

	public class PlayerCharacter : MonoBehaviour {
		private Animator m_Animator;

		public float m_MoveSpeed = 2.0f;

		private ShoppingList.Item[] m_ShoppingList;

		private GrocerItem m_ActiveItem;
		private void Awake() {
			m_Animator = GetComponent<Animator>();
		}

		// Start is called before the first frame update
		void Start() {

		}

		internal void Disable() {
			enabled = false;
		}

		// Update is called once per frame
		void Update() {
			float vertical = Input.GetAxis("Vertical");
			float horizontal = Input.GetAxis("Horizontal");

			m_Animator.SetFloat("Vertical", vertical);
			m_Animator.SetFloat("Horizontal", horizontal);

			Vector2 motion = new Vector2(horizontal, vertical);
			motion.Normalize();
			transform.Translate(motion * Time.deltaTime * m_MoveSpeed);
		}

		private void OnTriggerEnter2D(Collider2D collision) {

			if (collision.CompareTag("GrocerItem")) {

				GrocerItem newItem = collision.GetComponent<GrocerItem>();
				if (m_ActiveItem != null && newItem != m_ActiveItem) {
					float d1 = Vector3.Distance(transform.position, m_ActiveItem.transform.position);
					float d2 = Vector3.Distance(transform.position, newItem.transform.position);

					//if the second triggered object is closer, activate it instead
					if(d2 < d1) {
						m_ActiveItem = newItem;
					}
				} else {
					m_ActiveItem = newItem;
				}

				GameMenu.GetInstance().ShowContext(m_ActiveItem);
				//collision.GetComponent<GrocerItem>().ShowContext
			} else if (collision.CompareTag("Till")) {
				GameMenu.GetInstance().ShowContext(collision.GetComponent<TillMachine>());
			}
		}

		internal void Enable() {
			enabled = true;
		}

		internal ShoppingList.Item[] GetList() {
			return m_ShoppingList;
		}

		private void OnTriggerExit2D(Collider2D collision) {
			if (collision.CompareTag("GrocerItem")) {
				GameMenu.GetInstance().HideContext();
				m_ActiveItem = null;
			}
		}

		private void OnTriggerStay2D(Collider2D collision) {
			if (collision.CompareTag("GrocerItem") && m_ActiveItem == null) {
				m_ActiveItem = collision.GetComponent<GrocerItem>();
				GameMenu.GetInstance().ShowContext(m_ActiveItem);
			}
		}

		public void SetList(ShoppingList.Item[] shoppingList) {
			m_ShoppingList = shoppingList;
		}
	}
}