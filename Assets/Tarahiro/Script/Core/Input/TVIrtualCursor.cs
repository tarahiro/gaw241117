using System;
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using VContainer.Unity;
using static Tarahiro.TInput.TouchConst;

namespace Tarahiro.TInput
{
#if ENABLE_VIRTUAL_CURSOR
    public class TVIrtualCursor : Singleton<MonoVirtualCursor>
    {
    }
#endif
}