using UnityEngine;
using Utilities;

namespace VerticalShooter
{
    [CreateAssetMenu(fileName = "PlayerTrackingShot", menuName = "VerticalShooter/WeaponStrategy/PlayerTrackingShot")]
    public class TrackingShot : WeaponStrategy
    {
        [SerializeField] float trackingSpeed = 1f;

        Transform target;

        public override void Initialize()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public override void Fire(Transform firePoint, LayerMask layer)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            projectile.transform.SetParent(firePoint);
            projectile.layer = layer;

            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.SetSpeed(projectileSpeed);

            projectile.GetComponent<Projectile>().Callback = () =>
                {
                    // Get direction to target with same Z as fire point
                    Vector3 direction = (target.position - projectile.transform.position).With(firePoint.position.z).normalized;

                    // Rotate forward with Z as up direction
                    Quaternion rotation = Quaternion.LookRotation(direction, Vector3.forward);
                    projectile.transform.rotation = Quaternion.Slerp(projectile.transform.rotation, rotation, trackingSpeed * Time.deltaTime);
                };

            Destroy(projectile, projectileLifetime);
        }
    }
}
