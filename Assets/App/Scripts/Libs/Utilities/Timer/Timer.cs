using UnityEngine;

namespace App.Scripts.Libs.Utilities.Timer
{
    public class Timer : MonoBehaviour
    {
        private float _currentTime;
        
        private void Update()
        {
            _currentTime += Time.deltaTime;
        }

        public void SetActive(bool newState)
        {
            enabled = newState;
        }

        public float GetCurrentTime()
        {
            return _currentTime;
        }
    }
}