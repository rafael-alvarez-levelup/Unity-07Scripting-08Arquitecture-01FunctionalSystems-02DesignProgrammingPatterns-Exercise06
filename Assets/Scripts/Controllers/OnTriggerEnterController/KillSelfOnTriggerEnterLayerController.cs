using UnityEngine;

public class KillSelfOnTriggerEnterLayerController : OnTriggerEnterLayerControllerBase
{
    private ISelfKill killable;

    private void Awake()
    {
        killable = GetComponent<ISelfKill>();
    }

    protected override void React(Collider other)
    {
        killable.Kill();
    }
}