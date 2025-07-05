using _GameData.Scripts;
using System.Collections;
using UnityEngine;

namespace Assets._GameData.Scripts.UI
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuObj;

        public void PlayClick()
        {
            mainMenuObj.SetActive(false);

            EventManager.Instance.RaiseOnGameStarted();
        }
    }
}