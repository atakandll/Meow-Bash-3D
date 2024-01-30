using UnityEngine;

namespace Runtime
{
    public class CameraFollow : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private float distance;
        [SerializeField] private float height;
        [SerializeField] private Transform target;
        [SerializeField] private float smoothness;


        #endregion

        #region Private Variables
        private Vector3 _velocity;



        #endregion

        #endregion

        private void LateUpdate()
        {
            Vector3 pos = Vector3.zero;
            pos.x = target.position.x;
            pos.y = target.position.y + height;
            pos.z = target.position.z - distance;
            
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref _velocity, smoothness);
        }
    }
}