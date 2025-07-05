using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GameData.Scripts
{
    public class StageManager : Singleton<StageManager>
    {
        [SerializeField] private List<StageController> stageList;

        private int _currentStage;

        public Transform CurrentStageCar { get; private set; }
        public CarRecordData CurrentStageCarRecordData { get; private set; }

        private void OnEnable()
        {
            EventManager.Instance.OnGameStarted += OnGameStartedHandler;
            EventManager.Instance.OnStageCompleted += OnStageCompletedHandler;
            EventManager.Instance.OnStageFailed += OnStageFailedHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnGameStarted -= OnGameStartedHandler;
            EventManager.Instance.OnStageCompleted -= OnStageCompletedHandler;
            EventManager.Instance.OnStageFailed -= OnStageFailedHandler;
        }

        private void StartStage()
        {   
            stageList[_currentStage].InitPlayerStage();
            
            for (int i = 0; i < _currentStage; i++)
            {
                stageList[i].InitAIStage();
            }
            
            GetStageElements();
            EventManager.Instance.RaiseOnStageInitialized();
        }

        private void GetStageElements()
        {
            CurrentStageCar = stageList[_currentStage].CarInstance.transform;
            CurrentStageCarRecordData = stageList[_currentStage].CarRecordData;
        }

        private void OnGameStartedHandler()
        {
            StartStage();
        }

        private void OnStageCompletedHandler()
        {
            _currentStage++;

            if (_currentStage >= stageList.Count)
            {
                EventManager.Instance.RaiseOnGameWin();
            }
            else
            {
                StartStage();
            }
        }

        private void OnStageFailedHandler()
        {
            StartStage();
        }
    }
}