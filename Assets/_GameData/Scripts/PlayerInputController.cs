using UnityEngine;

namespace _GameData.Scripts
{
    public class PlayerInputController : MonoBehaviour
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
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
                _input = _mainCamera.ScreenToViewportPoint(Input.mousePosition).x <= 0.5f ? -1 : 1;
            else
                _input = 0;
        }
    }
}