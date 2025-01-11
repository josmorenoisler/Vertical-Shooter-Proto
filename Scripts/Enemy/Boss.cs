using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VerticalShooter
{
    public class Boss : MonoBehaviour
    {
        [SerializeField] float maxHealth = 100f;
        [SerializeField] GameObject explosionBossPrefab;
        float health;

        Collider bossCollider;

        public List<BossStage> Stages;

        int currentStage = 0;

        void Awake()
        {
            bossCollider = GetComponent<Collider>();
        }

        void Start()
        {
            health = maxHealth;
            bossCollider.enabled = true;

            InitializeStage();
        }

        public float GetHealthNormalized()
        {
            return health / maxHealth;
        }

        void CheckStageComplete()
        {
            if (Stages[currentStage] != null && Stages[currentStage].IsStageComplete())
            {
                AdvanceToNextStage();
            }
        }

        void AdvanceToNextStage()
        {
            currentStage++;
            bossCollider.enabled = true;

            if (currentStage < Stages.Count)
            {
                InitializeStage();
            }
        }

        void InitializeStage()
        {
            Stages[currentStage].InitializeStage();

            foreach (EnemyPlane system in Stages.SelectMany(stage => stage.enemySystems))
            {
                system.OnSystemDestroyed.AddListener(CheckStageComplete);
            }

            bossCollider.enabled = !Stages[currentStage].IsBossInvulnerable;
        }

        void OnCollisionEnter(Collision collision)
        {
            health -= 10;
            if (health <= 0)
            {
                BossDefeated();
            }
        }

        void BossDefeated()
        {
            Debug.Log("Boss Defeated!");
            Instantiate(explosionBossPrefab, transform.position, Quaternion.identity);
        }
    }
}
