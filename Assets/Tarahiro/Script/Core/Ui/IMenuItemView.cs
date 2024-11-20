using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarahiro;
using UniRx;
using UnityEngine;

namespace Tarahiro
{
    public interface IMenuItemView : ITransform
    {
        void Focus();

        void UnFocus();

        void Decide();
    }
}
