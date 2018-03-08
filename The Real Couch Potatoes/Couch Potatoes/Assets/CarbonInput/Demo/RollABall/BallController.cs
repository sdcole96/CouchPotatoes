using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace CarbonInput.Demo {
    /// <summary>
    /// Example script for the CarbonInput RollABall demo.
    /// </summary>
    public class BallController : MonoBehaviour {
        private static BallController instance;
        public float Speed;
        public float JumpSpeed;
        private Rigidbody rb;
        public Text ScoreText;
        public GameObject DropPrototype;

        // not necessary, but might me nice
        public CButton Jump = CButton.Y;

        void Start() {
            instance = this;
            rb = GetComponent<Rigidbody>();
     
        }

        

        void FixedUpdate() {
            // this will match real controllers, keyboard and also touch controls
            float moveX = GamePad.GetAxis(CAxis.LX);
            float moveZ = GamePad.GetAxis(CAxis.LY);

            Vector3 movement = new Vector3(moveX, 0f, -moveZ);
            if(IsGrounded() && GamePad.GetButton(Jump)) {
                movement.y = JumpSpeed;
            }

            rb.AddForce(movement * Speed);
        }

        bool IsGrounded() {
            // center of ball is at height 0.5
            return transform.position.y <= 0.5f;
        }
    }
}