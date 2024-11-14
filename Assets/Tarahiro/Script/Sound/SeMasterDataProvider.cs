using System.Collections;
using UnityEngine;
using Tarahiro.MasterData;

namespace Tarahiro.Sound
{
    public class SeMasterDataProvider : MasterDataProvider<SeMasterData.Record,IMasterDataRecord<ISeMaster>>, ISeMasterDataProvider
    {
        protected override string m_pathName => "Data/Se";
    }
}