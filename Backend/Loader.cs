﻿using Oxygen;
using UnityEngine;

namespace Loading
{
    public class Loader : MonoBehaviour
    {
        private static GameObject gameobject;
        public static bool loaded = false;
        public static void Load()
        {
            gameobject = new GameObject();
            gameobject.AddComponent<Plugin>();
            Object.DontDestroyOnLoad(gameobject);
        }

    }
}
