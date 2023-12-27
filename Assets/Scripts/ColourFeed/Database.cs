using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColourFeed
{
    public class Database : MonoBehaviour
    {
        [SerializeField] private static List<string> texts = new List<string>();

        void Start()
        {
            GenerateDatabase();
        }


        private void GenerateDatabase()
        {
            texts.Add("How does this colour make you feel?");
            texts.Add("Where did you last see this colour?");
            texts.Add("Remember the time when...");
            texts.Add("How are you feeling right now?");
        }

        public static string GetText(int val)
        {
            return texts[val];
        }
    }
}

