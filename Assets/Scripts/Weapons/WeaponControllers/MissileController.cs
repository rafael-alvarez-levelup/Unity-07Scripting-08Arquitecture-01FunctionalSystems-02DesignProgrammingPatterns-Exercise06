using UnityEngine;

public class MissileController : MonoBehaviour, ISearchAndDestroy
{
    private ISearchNearestTarget searcher;
    private IMoveToTarget mover;
    private ILookAtTarget looker;

    private void Awake()
    {
        searcher = GetComponent<ISearchNearestTarget>();
        mover = GetComponent<IMoveToTarget>();
        looker = GetComponent<ILookAtTarget>();
    }

    public void SearchAndDestroy()
    {
        Transform target = searcher.SearchNearestTarget();
        looker.SetTarget(target);
        mover.SetTarget(target);
    }
}