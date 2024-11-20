using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarahiro;
using UniRx;
using UnityEngine;

namespace Tarahiro
{
    public interface IMenuItemView
    {
        void Focus();

        void UnFocus();

        void Decide();
    }
}
