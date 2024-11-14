using System.Collections;
using UnityEngine;

namespace Tarahiro.Sound
{
    public interface ISeMaster : IIdentifiable, IIndexable
    {
        string SePath{ get; }
    }
}