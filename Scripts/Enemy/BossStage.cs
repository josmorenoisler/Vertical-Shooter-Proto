using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace VerticalShooter
{
    public class BossStage : MonoBehaviour
    {
        public List<EnemyPlane> enemySystems;
        public bool IsBossInvulnerable = true;

        void Start()
        {
            foreach (EnemyPlane system in enemySystems)
            {
                system.gameObject.SetActive(false);
            }
        }

        public void InitializeStage()
        {
            foreach (EnemyPlane system in enemySystems)
            {
                system.gameObject.SetActive(true);
            }
        }

        public bool IsStageComplete()
        {
            return enemySystems.All(system => system == null || system.GetHealthNormalized() <= 0);
        }
    }
}
