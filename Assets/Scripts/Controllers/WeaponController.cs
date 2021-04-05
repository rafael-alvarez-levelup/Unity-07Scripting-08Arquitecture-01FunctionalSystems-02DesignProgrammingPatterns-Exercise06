using UnityEngine;

// TODO: Refine weapon swap at runtime.

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponBase[] weapons;

    private int index = 0;

    private void Update()
    {
        // Allow weapon swap at run time respecting the open-close principle, but not in the best way (game design wise).
        if (Input.GetKeyDown(KeyCode.Q))
        {
            index = (index + 1) % weapons.Length;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weapons[index].CanFire())
            {
                weapons[index].Fire(firePoint);
                weapons[index].SetNextFireTime();
            }
        }
    }
}