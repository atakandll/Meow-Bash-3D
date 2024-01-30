using UnityEngine;

namespace Runtime
{
    public class SimpleTouchToMove : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public GameManager gameManager;
        public float Speed;
        public float gravity = 10f;
        public float JumpForce;
        public float StopForce;
        public GameObject jumpEffect;
        
        #endregion

        #region Private Variables
        
        private Animator _animator;
        private CharacterController _characterController;

        private Touch _touch;
        private Vector2 _initPos;
        private Vector2 _direction;
        private Vector3 _moveDirection;

        
        
        private bool canMove;
        
        #endregion

        #endregion
        
        private void Awake()
        {
            float bonusSpeed = 0.1f * PlayerPrefs.GetInt("speedLevel", 1);
            Speed += bonusSpeed;
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
        }
       

        void Update()
        {
            if (!gameManager.GameEnded && gameManager.GameStartarted)
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

                    if (_characterController.isGrounded)
                    {
                        _moveDirection = new Vector3(_touch.position.x - _initPos.x, 0, _touch.position.y - _initPos.y);
                        Quaternion targetRotation = _moveDirection != Vector3.zero ? Quaternion.LookRotation(_moveDirection) : transform.rotation;
                        transform.rotation = targetRotation;
                        _moveDirection = _moveDirection.normalized * Speed;
                    }
                }
                else
                {
                    canMove = false;
                    _moveDirection = Vector3.Lerp(_moveDirection, Vector3.zero, Time.deltaTime * StopForce);
                }
                _animator.SetBool("canWalk", canMove);

                if (Input.GetMouseButtonUp(0) && _characterController.isGrounded)
                {
                    Instantiate(jumpEffect, transform.position, Quaternion.identity);
                    _moveDirection.y += JumpForce;
                }
                _moveDirection.y -= (gravity * Time.deltaTime);
            
                _characterController.Move(_moveDirection * Time.deltaTime);
            }
            
        }
    }
}
