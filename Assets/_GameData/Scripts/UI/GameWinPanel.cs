using _GameData.Scripts;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._GameData.Scripts.UI
{
    public class GameWinPanel : MonoBehaviour
    {
        [SerializeField] private GameObject gameWinObj;

        private void OnEnable()
        {
            EventManager.Instance.OnGameWin += OnGameWinHandler;
        }

        private void OnDisable()
        {
            EventManager.Instance.OnGameWin -= OnGameWinHandler;
        }

        private void OnGameWinHandler()
        {
            Time.timeScale = 0f;
            gameWinObj.SetActive(true);
        }
    }
}