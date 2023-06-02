using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
    {
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Ship _ship;

        private void Awake()
        {
            _ship.Configure(GetInput());
        }

        private IInput GetInput()
        {
            if (_useJoystick)
            {
                return new JoystickInputAdapter(_joystick);
            }
            else
            {
                Destroy(_joystick.gameObject);
                return new UnityInputAdapter();
            }
        }
    }
}