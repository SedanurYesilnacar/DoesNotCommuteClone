using System.Collections;
using UnityEngine;

namespace Assets._GameData.Scripts.UI
{
    public class ResumeButton : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenuObj;

        public void ResumeClick()
        {
            pauseMenuObj.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}