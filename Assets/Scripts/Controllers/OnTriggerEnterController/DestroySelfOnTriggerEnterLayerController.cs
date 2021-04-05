using UnityEngine;

public class DestroySelfOnTriggerEnterLayerController : OnTriggerEnterLayerControllerBase
{
    private ISelfDestroyable destroyable;

    private void Awake()
    {
        destroyable = GetComponent<ISelfDestroyable>();
    }

    protected override void React(Collider other)
    {
        destroyable.Destroy();
    }
}