namespace _GameData.Scripts
{
    public class AIMovementController : CarMovementController
    {
        private InputRecordData _inputRecordData;
        
        private int _frameCounter;
        private bool _isReplaying;

        public void SetInputRecordData(InputRecordData inputRecordData) => _inputRecordData = inputRecordData;

        private void OnEnable()
        {
            EventManager.Instance.OnStageInitialized += OnStageInitializedHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStageInitialized -= OnStageInitializedHandler;
        }

        public void Stop()
        {
            movementSpeed = 0;
        }

        protected override void FixedUpdate()
        {
            if(!_isReplaying) return;
            
            Replay();
            base.FixedUpdate();
        }

        private void Replay()
        {
            if (_frameCounter < _inputRecordData.recordedData.Count)
            {
                input = _inputRecordData.recordedData[_frameCounter];
                _frameCounter++;
            }
        }

        private void OnStageInitializedHandler()
        {
            _isReplaying = true;
        }
    }
}