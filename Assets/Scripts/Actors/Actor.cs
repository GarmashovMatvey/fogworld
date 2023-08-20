using UnityEngine;

namespace RW.Actors
{
    [DisallowMultipleComponent]
    public sealed class Actor : MonoBehaviour
    {
        [SerializeField] private float _groundedAngleThreshold;
    }
}