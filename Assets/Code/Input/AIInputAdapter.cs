using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ships;

namespace Input
{
    public class AIInputAdapter : IInput
    {
        private readonly ShipMediator _ship;
        private int _currentDirectionX;

        public AIInputAdapter(ShipMediator ship)
        {
            _ship = ship;
            _currentDirectionX = 1;
        }

        public Vector2 GetDirection()
        {
            var viewportPoint = Camera.main.WorldToViewportPoint(_ship.transform.position);
            if (viewportPoint.x < 0.05f)
            {
                _currentDirectionX = 1;
            }
            else if (viewportPoint.x > 0.95f)
            {
                _currentDirectionX = -1;
            }

            return new Vector2(_currentDirectionX, 0);
        }

        public bool IsFireActionPressed()
        {
            return Random.Range(0, 100) < 20;
        }
    }
}