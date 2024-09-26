using App.Scripts.Libs.Infrastructure.UI.AnimatedView.AnimationConfig;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.UI.AnimatedView.CanvasGroup.Base
{
    public abstract class AnimatedCanvasGroupView : MonoBehaviour
    {
        [SerializeField] protected ConfigAnimation config;

        protected Tween LastTween;
        
        public abstract UniTask ShowAnimated();
        
        public abstract UniTask HideAnimated();

        public virtual void Show()
        {
            transform.SetAsLastSibling();
            gameObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            transform.SetAsFirstSibling();
            gameObject.SetActive(false);
        }
    }
}