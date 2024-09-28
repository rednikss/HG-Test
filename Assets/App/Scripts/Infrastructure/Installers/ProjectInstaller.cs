using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Infrastructure.UI.Panel.Manager;
using UnityEngine;

namespace App.Scripts.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private Transform canvasTransform;
        
        public override void InstallBindings(ServiceContainer container)
        {
            container.SetServiceSelf(new PanelManager(canvasTransform));
        }
    }
}