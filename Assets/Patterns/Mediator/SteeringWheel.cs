using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Mediator
{
    public class SteeringWheel : MonoBehaviour
    {
        private IVehicle _vehicle;

        public void Configure(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetButtonDown("Left"))
            {
                _vehicle.LeftPressed();
            }
            else if (UnityEngine.Input.GetButtonUp("Right"))
            {
                _vehicle.RightPressed();
            }
        }
    }
}