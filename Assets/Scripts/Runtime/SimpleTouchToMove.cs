using UnityEditor.UIElements;
using UnityEngine;

namespace Runtime
{
    public class SimpleTouchToMove : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        
        public CharacterController CharacterController;
        public float Speed = 6.0f;
        public float gravity = 10f;
        public float JumpForce = 3.0f;
        public float StopForce = 3.0f;
        
        #endregion

        #region Private Variables

        private Touch _touch;
        private Vector2 _initPos;
        private Vector2 _direction;
        private Vector3 _moveDirection;

        
        
        private bool canMove;
        
        #endregion

        #endregion
       

        void Update()
        {
            if (Input.touchCount > 0)
            {
                canMove = true;
                _touch = Input.GetTouch(0);
                
                if (_touch.phase == TouchPhase.Began)
                {
                    _initPos = _touch.position;
                }

                if (_touch.phase == TouchPhase.Moved)
                {
                    _direction = _touch.deltaPosition;
                }

                if (CharacterController.isGrounded)
                {
                    _moveDirection = new Vector3(_touch.position.x - _initPos.x, 0, _touch.position.y - _initPos.y);
                    Quaternion targetRotation = _moveDirection != Vector3.zero ? Quaternion.LookRotation(_moveDirection) : transform.rotation;
                    transform.rotation = targetRotation;
                    _moveDirection = _moveDirection * Speed;
                }
            }
            else
            {
                canMove = false;
                _moveDirection = Vector3.Lerp(_moveDirection, Vector3.zero, Time.deltaTime * StopForce);
            }

            if (Input.GetMouseButtonUp(0))
            {
                _moveDirection.y += JumpForce;
            }
            _moveDirection.y -= (gravity * Time.deltaTime);
            CharacterController.Move(_moveDirection * Time.deltaTime);


        }
    }
}
