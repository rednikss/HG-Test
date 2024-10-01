using System;
using System.Collections.Generic;
using App.Scripts.Libs.Patterns.StateMachine.State;

namespace App.Scripts.Libs.Utilities.Timer
{
    public class Timer : ITickable
    {
        private float _currentTime;

        private readonly List<ITickable> _tickables = new();
        
        private readonly List<TimerDelayedEvent> _events = new();
        
        public void Tick(float deltaTime)
        {
            _currentTime += deltaTime;

            for (int i = 0; i < _tickables.Count; i++)
            {
                _tickables[i].Tick(deltaTime);
            }
            
            for (var i = 0; i < _events.Count; i++)
            {
                CheckDelayedEvent(_events[i]);
            }
        }

        public void AddTickable(ITickable tickable)
        {
            _tickables.Add(tickable);
        }

        public void RemoveTickable(ITickable tickable)
        {
            _tickables.Remove(tickable);
        }
        
        public void AddDelayedEvent(float delay, Action delayedEvent)
        {
            _events.Add(new TimerDelayedEvent(_currentTime + delay, delayedEvent));
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