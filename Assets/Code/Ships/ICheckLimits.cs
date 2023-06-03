using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ships
{
    public interface ICheckLimits
    {
        void ClampFinalPosition();
    }
}