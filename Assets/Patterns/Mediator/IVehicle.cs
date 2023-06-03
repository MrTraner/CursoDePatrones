using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Patterns.Mediator
{
    public interface IVehicle
    {
        void BrakePressed();
        void BrakeRelease();
        void LeftPressed();
        void RightPressed();
        void ObstacleDetected();
    }
}