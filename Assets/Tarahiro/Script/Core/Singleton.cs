using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarahiro;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Tarahiro
{
    public class Singleton<T> : IInitializable where T : MonoBehaviour
    {
        protected static T _instance;

        public static T GetInstance()
        {
            TryGetInstance();
            return _instance;
        }

        public void Initialize()
        {
            TryGetInstance();
        }

        protected static void TryGetInstance()
        {
            if (_instance == null)
            {
                var g = new GameObject();
                g.name = typeof(T).Name;
                _instance = g.AddComponent<T>();
                GameObject.DontDestroyOnLoad(g);
            }
        }
    }
}
