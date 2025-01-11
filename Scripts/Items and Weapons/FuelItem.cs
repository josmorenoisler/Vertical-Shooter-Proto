using UnityEngine;

namespace VerticalShooter
{
    public class FuelItem : Item
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<PlayerPlane>().AddFuel(amount);
            Destroy(gameObject);
        }
    }
}
