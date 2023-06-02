using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        //[SerializeField] private Joystick _joystick;
        private IInput _input;
        //[SerializeField] private bool useJoystick;
        private Transform _myTransform;
        private Camera _camera;

        public void Configure(IInput input)
        {
            _input = input;
        }

        void Awake()
        {
            _myTransform = transform;
            _camera = Camera.main;
        }

        void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private Vector2 GetDirection()
        {
            /*if (useJoystick)
            {
                return new Vector2(_joystick.Horizontal, _joystick.Vertical);
            }
            else
            {
                var horizontalDir = Input.GetAxis("Horizontal");
                var verticalDir = Input.GetAxis("Vertical");

                return new Vector2(horizontalDir, verticalDir);
            }*/
            return _input.GetDirection();
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            
            ClampFinalPosition();
        }

        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);

            float minValue = 0.03f;
            float maxValue = 0.97f;

            viewportPoint.x = Mathf.Clamp(viewportPoint.x, minValue, maxValue);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, minValue, maxValue);

            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }
    }
}