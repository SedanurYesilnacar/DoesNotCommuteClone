using UnityEngine;

namespace _GameData.Scripts
{
    public class StageController : MonoBehaviour
    {
        [SerializeField] private Transform entranceTransform;
        [SerializeField] private ExitController exitController;
        [SerializeField] private GameObject carPrefab;

        public GameObject CarInstance { get; private set; }
        [field: SerializeField] public InputRecordData InputRecordData { get; private set; } = new InputRecordData();

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
            ai.SetInputRecordData(InputRecordData);
        }

        public void InitPlayerStage()
        {
            ResetStage();
            
            exitController.SetVisualVisibility(true);

            CarInstance = Instantiate(carPrefab, entranceTransform.position, entranceTransform.rotation, transform);
            CarInstance.AddComponent<PlayerMovementController>();
        }

        private void ResetStage()
        {
            exitController.SetVisualVisibility(false);
            
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