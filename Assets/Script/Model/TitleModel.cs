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
    public class TitleModel : ITitleModel
    {
        [Inject] ICoinModel _coinModel;

        event Action Entered;
        event Action Exit;

        public void InitializeModel(Action entered, Action exit)
        {
            Entered += entered;
            Exit += exit;
        }

        public void EnterModel()
        {
            Entered.Invoke();
        }
        public void ExitModel()
        {
            _coinModel.EnterModel();
            Exit.Invoke();
        }
    }
}