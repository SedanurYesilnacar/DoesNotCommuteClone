using UnityEngine;

namespace _GameData.Scripts
{
    public class ExitController : MonoBehaviour
    {
        [SerializeField] private LayerMask carLayer;
        [SerializeField] private GameObject exitVisual;

        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & carLayer) != 0)
            {
                EventManager.Instance.RaiseOnCarReachExit(this, other.gameObject);
            }
        }

        public void SetVisualVisibility(bool isVisible) => exitVisual.SetActive(isVisible);
    }
}