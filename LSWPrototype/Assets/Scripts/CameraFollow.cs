using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWSPrototype {
	public class CameraFollow : MonoBehaviour {

		public Transform m_Target;
		public float m_MoveSpeed = 2.0f;

		// Start is called before the first frame update
		void Start() {

		}

		// Update is called once per frame
		void Update() {

			Vector2 delta = m_Target.position - transform.position;
			transform.Translate(delta * Time.deltaTime * m_MoveSpeed);

		}
	}
}