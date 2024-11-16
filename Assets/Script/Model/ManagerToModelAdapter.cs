using Cysharp.Threading.Tasks;
using gaw241117;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UniRx;
using UnityEngine;
using Zenject;

namespace gaw241117.Model
{
    public class ManagerToModelAdapter : IManagerToModelAdapter
    {
        [Inject] ITitleModel _model;
        public void Enter()
        {
            _model.EnterModel();
        }
    }
}