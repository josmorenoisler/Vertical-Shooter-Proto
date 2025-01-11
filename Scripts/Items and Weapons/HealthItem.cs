using UnityEngine;

namespace VerticalShooter
{
    public class HealthItem : Item 
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<PlayerPlane>().AddHealth((int) amount);
            Destroy(gameObject);
        }
    }
}
