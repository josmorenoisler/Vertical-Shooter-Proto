using UnityEngine;

namespace VerticalShooter
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "VerticalShooter/EnemyType", order = 0)]

    public class EnemyType : ScriptableObject 
    {
        public GameObject enemyPrefab;
        public GameObject weaponPrefab;
        public float speed;
    }
}
