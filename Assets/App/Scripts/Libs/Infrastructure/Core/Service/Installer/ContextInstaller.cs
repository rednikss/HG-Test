using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Service.Installer
{
    public class ContextInstaller : MonoInstaller
    {
        [SerializeField] private MonoInstaller[] monoInstallers;

        public override void InstallBindings(ServiceContainer container)
        {
            foreach (var monoInstaller in monoInstallers)
            {
                monoInstaller.InstallBindings(container);
            }
        }
    }
}
