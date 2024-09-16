using UnityEngine;

public class HelperFunctions : MonoBehaviour
{
    #region Random

    public static int GetRandomIndex(int min, int max)
    {
        return Random.Range(min, max);
    }

    #endregion

    #region Layers

    public static bool ContainsLayer(int mask, int targetLayer) => mask == (mask | (1 << targetLayer));

    #endregion
}