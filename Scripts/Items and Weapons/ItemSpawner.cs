using MEC;
using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace VerticalShooter
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] Item[] itemPrefabs;
        [SerializeField] float spawnInterval = 3f;
        [SerializeField] float spawnRadius = 3f;

        CoroutineHandle coroutineSpawner;

        void Start()
        {
            coroutineSpawner = Timing.RunCoroutine(SpawnItems());    
        }

        void OnDestroy()
        {
            Timing.KillCoroutines(coroutineSpawner);
        }

        IEnumerator<float> SpawnItems()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(spawnInterval);
                Item item = Instantiate(itemPrefabs[UnityEngine.Random.Range(0, itemPrefabs.Length)]);
                item.transform.position = (transform.position + UnityEngine.Random.insideUnitSphere).With(z:0) * spawnRadius;
            }
        }
    }
}
