using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Infrastructure.UI.Panel.Manager;
using UnityEngine;

namespace App.Scripts.Infrastructure.Project.Installer
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private Transform _canvasTransform;

        public override void InstallBindings(ServiceContainer container)
        {
            container.SetServiceSelf(new PanelManager(_canvasTransform));
        }
    }
}