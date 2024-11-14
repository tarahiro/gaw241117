using System.Collections;
using UnityEngine;

namespace Tarahiro.MasterData
{
    public interface IMasterDataRecord<T> : IIdentifiable, IIndexable
    {
        /// <summary>
        /// マスターデータからマスターを生成します。
        /// </summary>
        T GetMaster();
    }
}