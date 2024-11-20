using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        Subject<IEnumerable<IOtherGameMaster>> _modelInitialized = new Subject<IEnumerable<IOtherGameMaster>>();
        public IObservable<IEnumerable<IOtherGameMaster>> ModelInitialized => _modelInitialized;

        /*
        public OtherGameModel(string gameCode)
        {

        }
        */

        public void InitializeModel()
        {
            List<IOtherGameMaster> _availableMasterData = new List<IOtherGameMaster>();
            for(int i = 0; i < _masterDataProvider.Count; i++)
            {
                var master = _masterDataProvider.TryGetFromIndex(i).GetMaster();
                if (master.CodeName != _gameCode)
                {
                    _availableMasterData.Add(master);
                }
            }
            _modelInitialized.OnNext(_availableMasterData);
        }

        public void SelectOtherGame(string id)
        {
            Application.OpenURL(_masterDataProvider.TryGetFromId(id).GetMaster().StoreUrlJp);
        }
    }
}