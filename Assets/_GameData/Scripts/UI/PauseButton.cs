using _GameData.Scripts;
using System.Collections;
using UnityEngine;

namespace Assets._GameData.Scripts.UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuObj;

        public void PauseClick()
        {
            Time.timeScale = 0f;
            pauseMenuObj.SetActive(true);

            EventManager.Instance.RaiseOnMenuClicked();
        }
    }
}