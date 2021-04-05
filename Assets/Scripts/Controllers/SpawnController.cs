using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    #endregion

    #region Unity Methods

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    #endregion

    #region My Methods

    private IEnumerator SpawnWaves()
    {
        WaitForSeconds waveDelay = new WaitForSeconds(delay);

        foreach (WaveData wave in waves)
        {
            WaitForSeconds memberDelay = new WaitForSeconds(wave.Delay);

            foreach (GameObject member in wave.Sequence)
            {
                Transform pointToSpawn = spawnPoints[HelperFunctions.GetRandomIndex(0, spawnPoints.Count)];

                Instantiate(member, pointToSpawn.position, pointToSpawn.rotation);

                yield return memberDelay;
            }

            yield return waveDelay;
        }
    }

    #endregion
}