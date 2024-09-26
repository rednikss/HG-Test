using App.Scripts.Libs.Infrastructure.UI.AnimatedView.CanvasGroup.Base;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.UI.AnimatedView.CanvasGroup.Fade
{
    public class FadeCanvasGroupView : AnimatedCanvasGroupView
    {
        [SerializeField] private UnityEngine.CanvasGroup _canvasGroup;

        public override UniTask ShowAnimated()
        {
            LastTween.Kill();
            
            LastTween = _canvasGroup.DOFade(1, config.duration)
                .SetEase(config.inEase)
                .SetLink(gameObject)
                .OnStart(base.Show);
            
            return LastTween.ToUniTask();
        }

        public override UniTask HideAnimated()
        {
            LastTween.Kill();

            LastTween = _canvasGroup.DOFade(0, config.duration)
                .SetEase(config.outEase)
                .SetLink(gameObject)
                .OnComplete(base.Hide);
            
            return LastTween.ToUniTask();
        }

        public override void Show()
        {
            _canvasGroup.alpha = 1;
            base.Show();
        }
        
        public override void Hide()
        {
            _canvasGroup.alpha = 0;
            base.Hide();
        }
    }
}
