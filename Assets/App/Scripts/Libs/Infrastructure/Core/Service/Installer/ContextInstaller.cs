using App.Scripts.Libs.Infrastructure.Core.EntryPoint.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.Service.Installer
{
    public class ContextInstaller : MonoInitializable
    {
        [SerializeField] private MonoInstaller.MonoInstaller[] monoInstallers;

        public override void Init()
        {
            var container = ProjectContext.ProjectContext.Instance.GetContainer();
            
            foreach (var monoInstaller in monoInstallers)
            {
                monoInstaller.InstallBindings(container);
            }
        }
    }
}
