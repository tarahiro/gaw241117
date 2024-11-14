using System.Collections.Generic;

namespace Tarahiro
{
    /// <summary>
    /// 辞書形式のマスターデータにアクセスするためのインターフェースです。
    /// </summary>
    public interface IMasterDataOrderedDictionary<T> where T : IIndexable, IIdentifiable
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

        /// <summary>
        /// 全データへの列挙子を取得します。
        /// </summary>
        IEnumerable<T> Enumerable { get; }
    }
}
