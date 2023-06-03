using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    public class ViewportCheckLimits : ICheckLimits
    {
        private readonly Transform _transform;
        private readonly Camera _camera;

        public ViewportCheckLimits(Transform transform, Camera camera)
        {
            _transform = transform;
            _camera = camera;
        }

        public void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_transform.position);

            float minValue = 0.03f;
            float maxValue = 0.97f;

            viewportPoint.x = Mathf.Clamp(viewportPoint.x, minValue, maxValue);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, minValue, maxValue);

            _transform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}