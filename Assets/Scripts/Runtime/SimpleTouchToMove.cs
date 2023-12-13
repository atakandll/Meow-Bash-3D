using UnityEngine;

namespace Runtime
{
    public class SimpleTouchToMove : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        
        public CharacterController CharacterController;
        private Vector3 _moveDirection;
        public float Speed = 6.0f;
        public float gravity = -9.8f;
        
        #endregion

        #region Private Variables

        private Touch _touch;
        private Vector2 _initPos;
        private Vector2 _direction;
        
        private bool canMove;
        
        #endregion

        #endregion
       

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0)
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
        }
    }
}
