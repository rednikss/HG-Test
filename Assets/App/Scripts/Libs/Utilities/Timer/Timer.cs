using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Utilities.Timer
{
    public class Timer : MonoBehaviour
    {
        private float _currentTime;

        private readonly List<TimerDelayedEvent> _events = new();
        
        private void Update()
        {
            _currentTime += Time.deltaTime;

            for (var i = 0; i < _events.Count; i++)
            {
                var delayedEvent = _events[i];
                CheckDelayedEvent(delayedEvent);
            }
        }

        public void AddDelayedEvent(float delay, Action delayedEvent)
        {
            _events.Add(new (_currentTime + delay, delayedEvent));
        }
        
        public void SetActive(bool newState)
        {
            enabled = newState;
        }

        public float GetCurrentTime()
        {
            return _currentTime;
        }

        private void CheckDelayedEvent(TimerDelayedEvent delayedEvent)
        {
            if (_currentTime < delayedEvent.InvokeTime) return;
            
            delayedEvent.DelayedEvent?.Invoke();
            _events.Remove(delayedEvent);
        }
        
        private class TimerDelayedEvent
        {
            public readonly float InvokeTime;
            public readonly Action DelayedEvent;

            public TimerDelayedEvent(float invokeTime, Action delayedEvent)
            {
                InvokeTime = invokeTime;
                DelayedEvent = delayedEvent;
            }
        }
    }
}