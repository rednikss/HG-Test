using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.EntryPoint.MonoInitializable
{
    public abstract class MonoInitializable : MonoBehaviour, IInitializable
    {
        public abstract void Init();
    }
}