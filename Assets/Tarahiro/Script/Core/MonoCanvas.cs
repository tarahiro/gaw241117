using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarahiro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using static Const;

namespace Tarahiro
{
    public class MonoCanvas : MonoBehaviour
    {
        const string prefabName = "Prefab/MonoCanvas";
        Canvas _canvas;
        CanvasScaler _canvasScaler;
        List<ObjectOnCanvas> _objectOnCanvasList = new List<ObjectOnCanvas>();

        private void Awake()
        {
            _canvas = Instantiate(Resources.Load<Canvas>(prefabName));
            DontDestroyOnLoad(_canvas);
            _canvasScaler = _canvas.GetComponent<CanvasScaler>();
            _canvasScaler.referenceResolution = Const.Resolution;
        }

        public void RegisterInstance(Transform objectTransform, Const.OrderOnMonoCanvas orderOnMonoCanvas)
        {
            var v = new ObjectOnCanvas(objectTransform, orderOnMonoCanvas);
            v.ObjectTransform.parent = _canvas.transform;
            _objectOnCanvasList.Insert(_objectOnCanvasList.Count(x => x.OrderOnMonoCanvas < v.OrderOnMonoCanvas), v);
            AlignChirdren();
        }

        void AlignChirdren()
        {
            for(int i = 0; i < _objectOnCanvasList.Count; i++)
            {
                _objectOnCanvasList[i].ObjectTransform.SetSiblingIndex(i);
            }
        }


        private class ObjectOnCanvas
        {
            public Transform ObjectTransform;
            public Const.OrderOnMonoCanvas OrderOnMonoCanvas;

            public ObjectOnCanvas(Transform objectTransform, Const.OrderOnMonoCanvas orderOnMonoCanvas)
            {
                ObjectTransform = objectTransform;
                OrderOnMonoCanvas = orderOnMonoCanvas;
            }
        }
    }
}
