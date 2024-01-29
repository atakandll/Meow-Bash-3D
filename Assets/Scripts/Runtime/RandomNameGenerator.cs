using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime
{
    public class RandomNameGenerator : MonoBehaviour
    {
        string[] names = {"Ksusha", "Boncuk", "Pamuk", "Zoltan", "Wilco", "Uri","Oslo", "Bubu", "Gogol","Fred"};

        private void Awake()
        {
            gameObject.name = names[Random.Range(0,names.Length)] ?? string.Empty;
        }
    }
}