﻿using System.Collections.Generic;
using App.Scripts.Libs.Infrastructure.Core.EntryPoint.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Libs.Patterns.ObjectPool
{
    public abstract class MonoBehaviourPool<TObject> : MonoInitializable, IObjectPool<TObject> where TObject : MonoBehaviour
    {
        [SerializeField] protected int startSize;

        [SerializeField] protected TObject prefab;
        
        private readonly Stack<TObject> _pool = new();

        private readonly List<TObject> _usingObjects = new();
        
        public override void Init()
        {
            for (int i = 0; i < startSize; i++)
            {
                Create();
            }
        }

        protected virtual TObject Create()
        {
            var newObject = Instantiate(prefab, transform);
            
            _usingObjects.Add(newObject);
            ReturnObject(newObject);

            return newObject;
        }

        public virtual TObject Get()
        {
            if (!_pool.TryPeek(out _)) Create();
            
            return TakeObject();
        }

        public virtual void ReturnObject(TObject pooledObject)
        {
            pooledObject.gameObject.SetActive(false);

            _usingObjects.Remove(pooledObject);
            _pool.Push(pooledObject);
        }

        protected virtual TObject TakeObject()
        {
            var pooledObject = _pool.Pop();
            _usingObjects.Add(pooledObject);
            
            pooledObject.gameObject.SetActive(true);

            return pooledObject;
        }

        protected virtual void DestroyObject(TObject pooledObject)
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