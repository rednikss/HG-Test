using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ContextInstaller contextInstaller;
        
        [SerializeField] private MonoInitializable.MonoInitializable[] monoInitializables;

        public void Awake()
        {
            var container = ProjectContext.ProjectContext.Instance.GetContainer();
            
            contextInstaller.InstallBindings(container);
            
            foreach (var initializable in monoInitializables) initializable.Init();
        }
    }
}