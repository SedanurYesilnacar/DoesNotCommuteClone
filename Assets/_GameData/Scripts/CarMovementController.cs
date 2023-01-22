using UnityEngine;

namespace _GameData.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class CarMovementController : MonoBehaviour
    {
        protected Rigidbody rb;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
    }
}