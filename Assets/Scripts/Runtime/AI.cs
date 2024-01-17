using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Runtime
{
    public class AI : MonoBehaviour
    {
        public NavMeshAgent agent;
        public float radius = 10;
        public Animator aiAnim;
        public int score = 0;
        public GameManager gameManager;
        public Texture[] skins;

        private void Start()
        {
            GetComponentInChildren<Renderer>().material.mainTexture = skins[Random.Range(0, skins.Length)];
        }

        public void StartGame()
        {
            agent.destination = RandomNavMeshLocation(radius);
            aiAnim.SetBool("canWalk", true);
            InvokeRepeating("ChangeDestination", Random.Range(8,12), Random.Range(8,12));
        }

        public Vector3 RandomNavMeshLocation(float radius)
        {
            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += transform.position;
            NavMeshHit hit;
            Vector3 finalPosition = Vector3.zero;
            if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
            {
                finalPosition = hit.position;
            }
            return finalPosition;

        }

        public void ChangeDestination()
        {
            agent.destination = RandomNavMeshLocation(radius);
        }

        private void Update()
        {
            if (gameManager.GameStartarted && agent.remainingDistance < 1.5f)
            {
                ChangeDestination();
            }
        }

        public void GetPoints(int scoreToAdd)
        {
            score += scoreToAdd;
        }
    }
}