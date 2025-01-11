using UnityEngine;
using UnityEngine.Events;

namespace VerticalShooter
{
    public class EnemyPlane : Plane
    {
        [SerializeField] GameObject explosionPrefab;

        protected override void Die()
        {
            GameManager.Instance.AddScore(10);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            OnSystemDestroyed?.Invoke();
            Destroy(gameObject);
        }

        public UnityEvent OnSystemDestroyed;
    }
}
