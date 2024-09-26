using App.Scripts.Libs.Infrastructure.UI.AnimatedView.CanvasGroup.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.UI.Panel.Controller
{
    public abstract class PanelController : MonoBehaviour
    {
        [SerializeField] protected AnimatedCanvasGroupView _groupView;
        
        public UniTask ShowAnimated()
        {
            return _groupView.ShowAnimated();
        }

        public UniTask HideAnimated()
        {
            return _groupView.HideAnimated();
        }

        public void Show()
        {
            _groupView.Show();
        }

        public void Hide()
        {
            _groupView.Hide();
        }
    }
}