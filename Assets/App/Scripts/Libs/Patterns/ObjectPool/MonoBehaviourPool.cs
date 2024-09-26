using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Libs.Patterns.ObjectPool
{
    public abstract class MonoBehaviourPool<TObject> : MonoBehaviour, IObjectPool<TObject> where TObject : MonoBehaviour
    {
        [SerializeField] protected int defaultSize;

        [SerializeField] protected TObject prefab;
        
        private readonly Stack<TObject> _pool = new();

        private readonly List<TObject> _usingObjects = new();
        
        private void Start()
        {
            for (int i = 0; i < defaultSize; i++) Create();
        }
        
        public virtual TObject Create()
        {
            var newBall = Instantiate(prefab, transform);
            ReturnObject(newBall);
            
            return newBall;
        }

        public virtual TObject Get()
        {
            if (!_pool.TryPeek(out TObject newBall)) newBall = Create();
            
            TakeObject(newBall);

            return newBall;
        }

        public virtual void ReturnObject(TObject pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
            
            _usingObjects.Remove(pooledObject);
            _pool.Push(pooledObject);
        }

        public virtual void TakeObject(TObject pooledObject)
        {
            pooledObject.gameObject.SetActive(true);

            _pool.Pop();
            _usingObjects.Add(pooledObject);
        }

        public virtual void DestroyObject(TObject pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }
        
        public virtual void Clear(bool clearUsing)
        {
            foreach (var obj in _pool) DestroyObject(obj);
            _pool.Clear();
            
            if (!clearUsing) return;

            foreach (var obj in _usingObjects) DestroyObject(obj);
            _usingObjects.Clear();
        }
    }
}