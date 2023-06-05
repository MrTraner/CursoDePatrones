using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;
using Ships.Weapons;

namespace Ships
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(WeaponController))]
    public class ShipMediator : MonoBehaviour, IShip
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private WeaponController _weaponController;

        private IInput _input;

        public void Configure(IInput input, ICheckLimits checkLimits)
        {
            _input = input;
            _movementController.Configure(this, checkLimits);
            _weaponController.Configure(this);
        }

        void Update()
        {
            var direction = _input.GetDirection();
            _movementController.Move(direction);
            TryShoot();
        }

        private void TryShoot()
        {
            if (_input.IsFireActionPressed())
                _weaponController.TryShoot();
        }
    }
}