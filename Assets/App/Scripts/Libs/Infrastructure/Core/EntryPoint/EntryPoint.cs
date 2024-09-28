using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private MonoInitializable.MonoInitializable[] monoInitializables;

        public void Awake()
        {
            foreach (var initializable in monoInitializables)
            {
                initializable.Init();
            }
        }
    }
}