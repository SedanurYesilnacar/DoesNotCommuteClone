using System;
using UnityEngine;

namespace _GameData.Scripts
{
    public class EventManager : Singleton<EventManager>
    {
        public Action OnGameStarted;
        public void RaiseOnGameStarted() => OnGameStarted?.Invoke();

        public Action OnGameWin;
        public void RaiseOnGameWin() => OnGameWin?.Invoke();

        public Action OnMenuClicked;
        public void RaiseOnMenuClicked() => OnMenuClicked?.Invoke();

        public Action<ExitController, GameObject> OnCarReachExit;
        public void RaiseOnCarReachExit(ExitController exit, GameObject car) => OnCarReachExit?.Invoke(exit, car);
        
        public Action OnStageInitialized;
        public void RaiseOnStageInitialized() => OnStageInitialized?.Invoke();
        
        public Action OnStageCompleted;
        public void RaiseOnStageCompleted() => OnStageCompleted?.Invoke();
        
        public Action OnStageFailed;
        public void RaiseOnStageFailed() => OnStageFailed?.Invoke();

    }
}