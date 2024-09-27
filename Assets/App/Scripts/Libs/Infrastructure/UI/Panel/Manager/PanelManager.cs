using System.Collections.Generic;
using App.Scripts.Libs.Infrastructure.UI.Panel.Controller;
using App.Scripts.Libs.Patterns.Factory;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.UI.Panel.Manager
{
    public class PanelManager
    {
        private readonly Transform _canvasTransform;
        
        private List<IFactory<PanelController>> _factories;

        private readonly List<PanelController> _panels = new();

        public PanelManager(Transform canvasTransform)
        {
            _canvasTransform = canvasTransform;
        }

        public void SetPanelPool(List<IFactory<PanelController>> factories)
        {
            _factories = factories;
        }
        
        public TController GetPanel<TController>() where TController : PanelController
        {
            return CreatePanel<TController>();
        }
        
        private TController CreatePanel<TController>() where TController : PanelController
        {
            foreach (var panelFactory in _factories)
            {
                if (panelFactory.GetType() != typeof(IFactory<TController>)) continue;
                
                var panelController = panelFactory.Create();
                panelController.Hide();
                panelController.transform.SetParent(_canvasTransform);
                _panels.Add(panelController);
                
                return (TController) panelController;
            }

            Debug.LogError($"Attempted to create non-existent {typeof(TController).Name}!");

            return null;
        }

        public PanelController GetActive()
        {
            return _panels.Count == 0 ? null : _panels[^1];
        }

        public void DestroyAll()
        {
            while (_panels.Count > 0)
            {
                var panel = _panels[0];
                Object.Destroy(panel.gameObject);
                _panels.RemoveAt(0);
            }
        }
    }
}