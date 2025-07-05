using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._GameData.Scripts.UI
{
    public class MenuButton : MonoBehaviour
    {
        public void MenuClick()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}