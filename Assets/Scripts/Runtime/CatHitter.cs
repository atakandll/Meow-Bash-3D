using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime
{
    public class CatHitter : MonoBehaviour
    {
        public GameObject[] hitParticles;
        
        private Rigidbody _rigidbody;
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.CompareTag("hittable"))
            {
                Debug.Log("object hitted" + hit.gameObject.name);
                hit.gameObject.tag = "hitted";
                _rigidbody = hit.gameObject.GetComponent<Rigidbody>();
                _rigidbody.isKinematic = false;
                _rigidbody.AddExplosionForce(75,transform.position + Vector3.down,15);
                Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.transform.position, Quaternion.identity);
            }
        }
    }
}