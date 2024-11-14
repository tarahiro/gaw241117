using System.Collections;
using UnityEngine;

namespace Tarahiro.MasterData
{
    public interface IMasterDataProvider<T> where T : IIndexable, IIdentifiable
    {  
        /// <summary>
       /// Indexからデータを取得します。
       /// <para> * 存在しない場合、Tのdefaultを返します。</para>
       /// </summary>
        T TryGetFromIndex(int index);

        /// <summary>
        /// IDからデータを取得します。
        /// <para> * 存在しない場合、Tのdefaultを返します。</para>
        /// </summary>
        T TryGetFromId(string id);

        /// <summary>
        /// データの総数を取得します。
        /// </summary>
        int Count { get; }
    }
}