using System;
using UnityEngine;

namespace _GameData.Scripts
{
    public class ExitController : MonoBehaviour
    {
        [SerializeField] private LayerMask carLayer;

        private void OnTriggerEnter(Collider other)
        {
            if (((1 << other.gameObject.layer) & carLayer) != 0)
            {
                EventManager.Instance.RaiseOnCarReachExit(other.gameObject);
            }
        }
    }
}