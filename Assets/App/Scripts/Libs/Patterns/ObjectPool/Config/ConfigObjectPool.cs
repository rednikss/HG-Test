using UnityEngine;

namespace App.Scripts.Libs.Patterns.ObjectPool.Config
{
    [CreateAssetMenu(fileName = "Default Object Pool Config", menuName = "Scriptable Object/Base/Object Pool Config", order = 0)]
    public class ConfigObjectPool : ScriptableObject
    {
        [Min(0)] public int defaultSize;
        
        [Min(0)] public int maximumSize;
    }
}