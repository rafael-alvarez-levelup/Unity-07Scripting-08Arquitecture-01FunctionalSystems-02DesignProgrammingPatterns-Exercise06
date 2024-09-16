using System.Collections;
using UnityEngine;

public class DestroyOnTimerBehaviour : MonoBehaviour
{
    [SerializeField] private float time;

    private void OnEnable()
    {
        StartCoroutine(DestroyOnTimerRoutine());
    }

    private IEnumerator DestroyOnTimerRoutine()
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject, time);
    }
}