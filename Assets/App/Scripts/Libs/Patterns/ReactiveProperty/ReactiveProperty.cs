using System;

namespace App.Scripts.Libs.Patterns.ReactiveProperty
{
    public class ReactiveProperty<T>
    {
        public event Action<T> OnValueChanged;

        private T _value;
        
        public T Value
        {
            get => _value;
            
            set
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }
}