using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace gaw241117.Model
{
    public class ClearModel : IClearModel
    {
        public void ToTitle()
        {
            SceneManager.LoadScene("Main");
        }
    }
}