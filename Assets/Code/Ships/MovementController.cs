using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private IShip _ship;
        private Transform _myTransform;
        private ICheckLimits _checkLimits;

        public void Configure(IShip ship, ICheckLimits checkLimits)
        {
            _ship = ship;
            _checkLimits = checkLimits;
        }

        void Awake()
        {
            _myTransform = transform;
        }

        public void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));

            _checkLimits.ClampFinalPosition();
        }
    }
}