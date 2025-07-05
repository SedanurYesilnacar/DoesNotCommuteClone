using System.Collections;
using UnityEngine;

namespace Assets._GameData.Scripts
{
    public class CarProperty : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody rb { get; private set; }
        [field: SerializeField] public Transform carVisualRoot { get; private set; }
        [field: SerializeField] public ParticleSystem crashParticle { get; private set; }
        [field: SerializeField] public ArrowController arrow { get; private set; }
    }
}