using UnityEngine;

namespace _GameData.Scripts
{
    public class StageController : MonoBehaviour
    {
        [SerializeField] private Transform entranceTransform;
        [SerializeField] private ExitController exitController;
        [SerializeField] private GameObject carPrefab;

        public GameObject CarInstance { get; private set; }
        public CarRecordData CarRecordData { get; } = new();

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
            
            CarInstance = Instantiate(carPrefab, entranceTransform.position, entranceTransform.rotation, transform);
            AIMovementController ai = CarInstance.AddComponent<AIMovementController>();
            ai.Init(CarRecordData);
        }

        public void InitPlayerStage()
        {
            ResetStage();
            
            exitController.SetVisibility(true);

            CarInstance = Instantiate(carPrefab, entranceTransform.position, entranceTransform.rotation, transform);
            CarInstance.AddComponent<PlayerMovementController>();
        }

        private void ResetStage()
        {
            exitController.SetVisibility(false);
            
            if(CarInstance == null) return;
            
            Destroy(CarInstance);
        }

        private void OnCarReachExitHandler(ExitController exit, GameObject car)
        {
            if(exit != exitController) return;
            if (car != CarInstance) return;

            if (car.TryGetComponent(out AIMovementController aiController)) aiController.Stop();
            else EventManager.Instance.RaiseOnStageCompleted();
        }
    }
}