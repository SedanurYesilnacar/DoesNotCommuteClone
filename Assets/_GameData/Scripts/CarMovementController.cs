using Assets._GameData.Scripts;
using UnityEngine;

namespace _GameData.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class CarMovementController : MonoBehaviour
    {
        protected Rigidbody rb;
        protected CarProperty carProperty;
    }
}