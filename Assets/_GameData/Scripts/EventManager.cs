using System;
using UnityEngine;

namespace _GameData.Scripts
{
    public class EventManager : Singleton<EventManager>
    {
        public Action<GameObject> OnCarReachExit;
        public void RaiseOnCarReachExit(GameObject car) => OnCarReachExit?.Invoke(car);
        
        public Action<Transform> OnStageInitialized;
        public void RaiseOnStageInitialized(Transform currentPlayer) => OnStageInitialized?.Invoke(currentPlayer);
        
        public Action OnStageCompleted;
        public void RaiseOnStageCompleted() => OnStageCompleted?.Invoke();

    }
}