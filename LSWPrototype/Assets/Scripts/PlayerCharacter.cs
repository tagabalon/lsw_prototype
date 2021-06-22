using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {

	public class PlayerCharacter : MonoBehaviour {
		private Animator m_Animator;

		public float m_MoveSpeed = 2.0f;

		private void Awake() {
			m_Animator = GetComponent<Animator>();
		}

		// Start is called before the first frame update
		void Start() {

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
	}
}