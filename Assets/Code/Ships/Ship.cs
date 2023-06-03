using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private IInput _input;
        private Transform _myTransform;
        private ICheckLimits _checkLimits;

        public void Configure(IInput input, ICheckLimits checkLimits)
        {
            _input = input;
            _checkLimits = checkLimits;
        }

        void Awake()
        {
            _myTransform = transform;
        }

        void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private Vector2 GetDirection()
        {
            return _input.GetDirection();
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));

            _checkLimits.ClampFinalPosition();
        }
    }
}