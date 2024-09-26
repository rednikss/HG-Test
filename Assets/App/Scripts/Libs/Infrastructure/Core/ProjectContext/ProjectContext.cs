using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.ProjectContext
{
    public class ProjectContext : MonoBehaviour
    {
        [SerializeField] private ContextInstaller contextInstaller;
        
        private ServiceContainer _container;

        private static ProjectContext _instance;
        
        public static ProjectContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<ProjectContext>("Project Context");
                    _instance = Instantiate(_instance);
                    DontDestroyOnLoad(_instance);
                    
                    _instance.Init();
                }
                
                return _instance;
            }
        }

        public void Init()
        {
            _container = new ServiceContainer();
            
            contextInstaller.InstallBindings(_container);
        }

        public ServiceContainer GetContainer() => _container;
    }
}