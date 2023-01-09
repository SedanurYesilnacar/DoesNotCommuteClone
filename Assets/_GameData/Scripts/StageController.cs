using System;
using UnityEngine;

namespace _GameData.Scripts
{
    public class StageController : MonoBehaviour
    {
        [SerializeField] private Transform entranceTransform;
        [SerializeField] private GameObject carPrefab;
        
        private GameObject _carInstance;

        private void OnEnable()
        {
            EventManager.Instance.OnCarReachExit += OnCarReachExitHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnCarReachExit -= OnCarReachExitHandler;
        }

        public void InitAIStage()
        {
            ResetStage();
            
            _carInstance = Instantiate(carPrefab, entranceTransform.position, entranceTransform.rotation, transform);
            _carInstance.AddComponent<AIMovementController>();
        }

        public void InitPlayerStage()
        {
            ResetStage();
            
            _carInstance = Instantiate(carPrefab, entranceTransform.position, entranceTransform.rotation, transform);
            _carInstance.AddComponent<PlayerMovementController>();
            
            EventManager.Instance.RaiseOnStageInitialized(_carInstance.transform);
        }

        private void ResetStage()
        {
            if(_carInstance == null) return;
            
            Destroy(_carInstance);
        }

        private void OnCarReachExitHandler(GameObject car)
        {
            if (car == _carInstance)
            {
                if (car.TryGetComponent(out AIMovementController aiController)) aiController.Stop();
                else EventManager.Instance.RaiseOnStageCompleted();
            }
        }
    }
}