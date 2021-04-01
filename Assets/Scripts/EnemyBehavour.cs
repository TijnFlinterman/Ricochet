using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavour : MonoBehaviour
{
    public GameObject sparks;
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            Instantiate(sparks, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            Destroy(this.gameObject);
        }
    }
}
