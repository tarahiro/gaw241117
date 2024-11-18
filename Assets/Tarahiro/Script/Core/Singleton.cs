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
        static T _instance;

        public static T GetInstance()
        {
            if(_instance == null)
            {
                CreateInstance();
            }
            return _instance;
        }

        public void Initialize()
        {
            CreateInstance();
        }

        static void CreateInstance()
        {
            var g = new GameObject();
            _instance = g.AddComponent<T>();
            GameObject.DontDestroyOnLoad(g);

        }
    }
}
