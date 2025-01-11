using UnityEngine;

namespace VerticalShooter
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected float amount = 10f;
    }
}
