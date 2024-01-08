using System;
using UnityEngine;

namespace Runtime
{
    public class Bilboard : MonoBehaviour
    {
        private void Update()
        {
            transform.LookAt(Camera.main.transform);
        }
    }
}