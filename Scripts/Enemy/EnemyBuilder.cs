using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using Utilities;

namespace VerticalShooter
{
    public class EnemyBuilder 
    {
        GameObject enemyPrefab;
        SplineContainer splineContainer;
        GameObject weaponPrefab;
        float speed;

        public EnemyBuilder SetBasePrefab(GameObject prefab)
        {
            enemyPrefab = prefab;
            return this;
        }

        public EnemyBuilder SetSpline(SplineContainer spline)
        {
            splineContainer = spline;
            return this;
        }

        public EnemyBuilder SetWeaponPrefab(GameObject weapon)
        {
            weaponPrefab = weapon;
            return this;
        }

        public EnemyBuilder SetSpeed(float speedToSet)
        {
            speed = speedToSet;
            return this;
        }

        public GameObject Build()
        {
            GameObject instance = GameObject.Instantiate(enemyPrefab);

            SplineAnimate splineAnimate = instance.GetOrAdd<SplineAnimate>();
            splineAnimate.Container = splineContainer;
            splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            splineAnimate.ObjectUpAxis = SplineAnimate.AlignAxis.ZAxis;
            splineAnimate.ObjectForwardAxis = SplineAnimate.AlignAxis.YAxis;
            splineAnimate.MaxSpeed = speed;
            splineAnimate.Restart(true);

            // Set instance transform to spline start position
            instance.transform.position = splineContainer.EvaluatePosition(0f);
            // For future reference: if instantiating waves, could set the position along the spline in a staggered value 0f to 1f

            return instance;
        }
    }
}
