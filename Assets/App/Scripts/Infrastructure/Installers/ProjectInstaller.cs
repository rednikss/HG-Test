using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Infrastructure.UI.Panel.Manager;
using App.Scripts.Libs.Utilities.Timer;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private Transform _canvasTransform;

        [SerializeField] private Timer _timer;
        public override void InstallBindings(ServiceContainer container)
        {
            container.SetServiceSelf(new PanelManager(_canvasTransform));
            
            container.SetServiceSelf(_timer);
        }
    }
}