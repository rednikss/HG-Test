using App.Scripts.Libs.Infrastructure.Core.EntryPoint.MonoInitializable;
using App.Scripts.Libs.Infrastructure.UI.AnimatedView.AnimationConfig;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.UI.AnimatedView.Slider
{
    public class AnimatedSliderView : MonoInitializable
    {
        [SerializeField] private ConfigAnimation config;
        
        [SerializeField] protected UnityEngine.UI.Slider slider;

        public override void Init()
        {
        }
        
        public UniTask SetValueAnimated(float newValue)
        {
            newValue = ClampValue(newValue);
            
            return DOTween.To(GetValue, SetValue, newValue, config.duration)
                .SetEase(config.inEase)
                .SetLink(gameObject)
                .ToUniTask();
        }

        private float GetValue() => slider.value;
        
        public void SetValue(float newValue) => slider.value = ClampValue(newValue);
        
        public void SetMaxValue(float newValue) => slider.maxValue = newValue;
        
        public void SetMinValue(float newValue) => slider.minValue = newValue;

        private float ClampValue(float newValue) => Mathf.Clamp(newValue, slider.minValue, slider.maxValue);
    }
}