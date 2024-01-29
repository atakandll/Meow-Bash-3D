using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Runtime
{
    public class RandomNameGenerator : MonoBehaviour
    {
        string[] names = {"Ksusha", "Boncuk", "Maestro", "Zoltan", "Wilco", "Uri","Oslo", "Bubu", "Gogol","Fred", "Tolik","Frank", "George","Ava","Betty","Cindy","Diana","Elena","Fiona","Gina","Hanna","Ivan","Jana"};

        private void Awake()
        {
            gameObject.name = names[Random.Range(0,names.Length)] ?? string.Empty;
        }
    }
}