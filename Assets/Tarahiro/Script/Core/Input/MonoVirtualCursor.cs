
using System.Collections;
using System.Collections.Generic;
using Tarahiro;
using UnityEngine;
using VContainer.Unity;
using static Tarahiro.TInput.TouchConst;

namespace Tarahiro.TInput
{
#if ENABLE_VIRTUAL_CURSOR
    public class MonoVirtualCursor : MonoBehaviour
    {
        const string c_prefabName = "Prefab/Cursor";
        Transform _cursorTransform;

        private void Start()
        {
            _cursorTransform = Instantiate(Resources.Load<Transform>(c_prefabName));
            TCanvas.GetInstance().RegisterInstance(_cursorTransform , Const.OrderOnMonoCanvas.Cursor);
        }

        private void Update()
        {
            _cursorTransform.localPosition = TTouch.GetInstance().ScreenPointOnThisFrame - Const.Resolution * .5f;
        }
    }
#endif
}
