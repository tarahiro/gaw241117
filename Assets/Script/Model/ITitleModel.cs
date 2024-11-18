using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace gaw241117.Model
{
    public interface ITitleModel
    {
        void InitializeModel(Action entered, Action exit);

        void EnterModel();
        void ExitModel();
    }
}