using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

namespace Runtime
{
    public class CatHitter : MonoBehaviour
    {
        public GameObject TextScore;
        public GameObject TextScore3D;
        public GameObject[] hitParticles;
        public GameManager gameManager;
        public bool isAI = false;
        
        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (!isAI)
            {
                if (hit.gameObject.CompareTag("hittable"))
                {
                    hit.gameObject.tag = "hitted";
                    Rigidbody _rigidbody = hit.gameObject.GetComponent<Rigidbody>();
                    HittableObjects hittableObjects = hit.gameObject.GetComponent<HittableObjects>();
                    HitEffect(_rigidbody,hit);
                    Score3DEffect(hittableObjects);
                    GetCoins(hittableObjects);
                
                } 
            }
              
        }
        public void GetCoins(HittableObjects hittableObjects)
        {
            int currentCoins = PlayerPrefs.GetInt("coins", 0);

            if (currentCoins + hittableObjects.coins > 99999999)
            {
                PlayerPrefs.SetInt( "coins", 99999999);
            }
            else
                PlayerPrefs.SetInt("coins", currentCoins + hittableObjects.coins);
        }

        public void HitEffect(Rigidbody _rigidbody, ControllerColliderHit hit)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddExplosionForce(75,transform.position + Vector3.down,15);
            Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.transform.position, Quaternion.identity);
            iTween.PunchScale(TextScore,new Vector3(1.25f,1.25f,1.25f),.3f);
        }

        public void Score3DEffect(HittableObjects hittableObjects)
        {
            int newScore = int.Parse(TextScore.GetComponent<TextMeshProUGUI>().text) + hittableObjects.Points;
            TextScore.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
            TextScore3D.GetComponent<TextMesh>().text = "+" + hittableObjects.Points;
            iTween.PunchScale(TextScore3D,new Vector3(1.25f,1.25f,1.25f),.5f);
            Invoke("Reset",.5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isAI && gameManager.GameStartarted  && !gameManager.GameEnded)
            {
                if (other.gameObject.CompareTag("hittable"))
                {
                    Rigidbody _rigidbody = other.gameObject.GetComponent<Rigidbody>();
                    HittableObjects _hittableObjects = other.gameObject.GetComponent<HittableObjects>();
                    _rigidbody.isKinematic = false;
                    _rigidbody.AddExplosionForce(75,transform.position + Vector3.down,15);
                    Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], other.gameObject.transform.position, Quaternion.identity);
                    iTween.PunchScale(TextScore,new Vector3(1.25f,1.25f,1.25f),.3f);

                    if (other.gameObject.name != "touched")
                    {
                        //calculate the coins and score for ai
                        AI ai = GetComponent<AI>();
                        ai.GetPoints(_hittableObjects.Points * 3);
                    }
                    other.gameObject.name = "touched";
                    
                }
            }
        }

        public void Reset()
        {
            TextScore3D.GetComponent<TextMesh>().text = "";
        }
    }
}