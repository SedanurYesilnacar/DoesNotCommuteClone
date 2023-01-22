using UnityEngine;

namespace _GameData.Scripts
{
    public class InputManager : Singleton<InputManager>
    {
        public int GetInput => _input;
        private int _input;
        
        private Camera _mainCamera;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            _input = Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)
                ? _mainCamera.ScreenToViewportPoint(Input.mousePosition).x <= 0.5f ? -1 : 1
                : 0;
        }
    }
}