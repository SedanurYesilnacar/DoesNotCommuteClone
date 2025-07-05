using System.Collections;
using UnityEngine;

namespace Assets._GameData.Scripts.UI
{
    public class ExitButton : MonoBehaviour
    {
        public void ExitClick()
        {
            Application.Quit();
        }
    }
}