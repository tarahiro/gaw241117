using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarahiro;
using UniRx;
using UnityEngine;

namespace Tarahiro.UI
{
    public interface IMenuView
    {
        void Enter();

        void Exit();
    }
}
