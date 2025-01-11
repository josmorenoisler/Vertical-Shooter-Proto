using UnityEngine;

namespace VerticalShooter
{
    public class PlayerWeapon : Weapon
    {
        InputReader inputReader;
        float fireTimer;

        void Awake()
        {
            inputReader = GetComponent<InputReader>();
        }

        void Update()
        {
            fireTimer += Time.deltaTime;

            if (inputReader.Fire && fireTimer >= weaponStrategy.FireRate)
            {
                weaponStrategy.Fire(firePoint, layer);
                fireTimer = 0f;
            }
        }
    }
}
