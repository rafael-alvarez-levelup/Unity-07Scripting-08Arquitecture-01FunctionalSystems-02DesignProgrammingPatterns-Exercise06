using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DONE

// TODO: Modularize (SRP).

/// <summary>
/// Manages the instantiation of enemies.
/// </summary>
public class SpawnController : MonoBehaviour
{
    #region Private Fields

    [SerializeField] private List<WaveData> waves = new List<WaveData>();
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private float delay;

    private IObjectPooling enemiesPoolingManager;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        enemiesPoolingManager = FindObjectOfType<EnemiesPoolingManager>();

        InitializeEnemiesPool();
    }

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    #endregion

    #region My Methods

    private void InitializeEnemiesPool()
    {
        List<GameObject> prefabs = new List<GameObject>();

        foreach (var wave in waves)
        {
            foreach (var prefab in wave.Sequence)
            {
                prefabs.Add(prefab);
            }
        }

        enemiesPoolingManager.InitializePool(prefabs);
    }

    private IEnumerator SpawnWaves()
    {
        WaitForSeconds waveDelay = new WaitForSeconds(delay);

        foreach (WaveData wave in waves)
        {
            WaitForSeconds memberDelay = new WaitForSeconds(wave.Delay);

            for (int i = 0; i < wave.Sequence.Count; i++)
            {
                Transform pointToSpawn = spawnPoints[HelperFunctions.GetRandomIndex(0, spawnPoints.Count)];

                // Doesn't need a prefab, it's a fixed sequence
                enemiesPoolingManager.Spawn(pointToSpawn.position, pointToSpawn.rotation);

                yield return memberDelay;
            }

            yield return waveDelay;
        }
    }

    #endregion
}