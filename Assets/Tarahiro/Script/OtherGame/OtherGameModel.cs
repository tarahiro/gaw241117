using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using Tarahiro.Ui;
using UniRx;
using UnityEngine;
using VContainer;

namespace Tarahiro.OtherGame
{
    public class OtherGameModel : IOtherGameModel
    {
        [Inject] string _gameCode;
        [Inject] IOtherGameMasterDataProvider _masterDataProvider;

        /*
        public OtherGameModel(string gameCode)
        {

        }
        */

        public void InitializeModel(Action<List<string>> modelInitialized)
        {
            List<string> pathList = new List<string>();
            for(int i = 0; i < _masterDataProvider.Count; i++)
            {
                var master = _masterDataProvider.TryGetFromIndex(i).GetMaster();
                if (master.Id != _gameCode)
                {
                    pathList.Add(master.IconPathJp);
                }
            }
            modelInitialized.Invoke(pathList);
        }
    }
}