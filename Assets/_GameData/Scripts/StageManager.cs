using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GameData.Scripts
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField] private List<StageController> stageList;

        private int _currentStage;

        private void Start()
        {
            stageList[0].InitPlayerStage();
        }

        private void OnEnable()
        {
            EventManager.Instance.OnStageCompleted += OnStageCompletedHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnStageCompleted -= OnStageCompletedHandler;
        }

        private void OnStageCompletedHandler()
        {
            StartNextStage();
        }

        private void StartNextStage()
        {
            _currentStage++;
            if (_currentStage > stageList.Count - 1) _currentStage = 0;
            
            stageList[_currentStage].InitPlayerStage();
            
            for (int i = 0; i < _currentStage; i++)
            {
                stageList[i].InitAIStage();
            }
        }
    }
}