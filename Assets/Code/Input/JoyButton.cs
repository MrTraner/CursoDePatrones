using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public bool IsPresssed { get; private set; }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsPresssed = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsPresssed = true;
        }
    }
}