using App.Scripts.Libs.Infrastructure.UI.AnimatedView.AnimationConfig;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.UI.AnimatedView.Button.Config
{
    [CreateAssetMenu(fileName = "Button Animation Config", menuName = "Scriptable Object/View/Button Animation Config", order = 0)]
    public class ConfigButtonAnimation : ConfigAnimation
    {
        [Range(0, 1)] 
        public float pressedScale = 0.9f;
    }
}