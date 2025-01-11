using UnityEngine;

namespace VerticalShooter
{
    public class PlayerPlane : Plane
    {
        [SerializeField] float maxFuel;
        [SerializeField] float fuelConsumptionRate;
        float fuel;

        void Start()
        {
            fuel = maxFuel;
        }

        public float GetFuelNormalized()
        {
            return (fuel / maxFuel);
        }

        public void AddFuel(float amount)
        {
            fuel += amount;
            if (fuel > maxFuel)
            {
                fuel = maxFuel;
            }
        }

        void Update()
        {
            fuel -= fuelConsumptionRate * Time.deltaTime;
        }

        protected override void Die()
        {
            Destroy(gameObject);
        }
    }
}
