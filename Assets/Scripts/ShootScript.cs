using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int bulletCount = 5;

    public void ButtonShoot()
    {
        if (bulletCount != 0)
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
            bulletCount -= 1;
        }
    }
}
