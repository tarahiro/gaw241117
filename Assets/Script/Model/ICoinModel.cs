using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace gaw241117.Model
{

    public interface ICoinModel
    {
        void InitializeModel(Action entered);
        void EnterModel();

    }
}