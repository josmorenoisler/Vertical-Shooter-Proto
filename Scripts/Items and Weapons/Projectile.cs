using System;
using UnityEngine;

namespace VerticalShooter
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] GameObject muzzlePrefab;
        [SerializeField] GameObject hitPrefab;

        Transform parent;

        public void SetSpeed(float speedToSet)
        {
            this.speed = speedToSet;
        }
        public void SetParent(Transform parentToSet)
        {
            this.parent = parentToSet;
        }

        public Action Callback;

        void Start()
        {
            if (muzzlePrefab != null) 
            {
                GameObject muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
                muzzleVFX.transform.forward = gameObject.transform.forward;
                muzzleVFX.transform.SetParent(parent);

                DestroyParticleSystem(muzzleVFX);
            }
        }

        void Update()
        {
            transform.SetParent(null);
            transform.position += transform.forward * (speed * Time.deltaTime);

            Callback?.Invoke();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (hitPrefab != null)
            {
                ContactPoint contact = collision.contacts[0];
                GameObject hitVFX = Instantiate(hitPrefab, contact.point, Quaternion.identity);

                DestroyParticleSystem(hitVFX);
            }

            Plane plane = collision.gameObject.GetComponent<Plane>();
            if (plane != null) 
            {
                plane.TakeDamage(10);
            }

            Destroy(gameObject);
        }

        private void DestroyParticleSystem(GameObject muzzleVFX)
        {
            ParticleSystem particleSystem = muzzleVFX.GetComponent<ParticleSystem>();

            if (particleSystem != null)
            {
                particleSystem = muzzleVFX.GetComponentInChildren<ParticleSystem>();
            }

            Destroy(muzzleVFX, particleSystem.main.duration);
        }
    }
}
