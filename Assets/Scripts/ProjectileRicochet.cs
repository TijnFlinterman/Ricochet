using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileRicochet : MonoBehaviour
{
    public LayerMask collisionMask;
    public LayerMask ignoreRaycastmask;
    public GameObject sparks;

    public Transform bullet;
    private float speed = 30;
    private int maxBounce = 5;

    void FixedUpdate()
    {
            Vector3 forW  = Vector3.forward * Time.deltaTime * speed;
            forW.y = 0;
            transform.Translate(forW);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Time.deltaTime * speed, collisionMask))
            {
                Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
                float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, rot, 0);
                maxBounce -= 1;
            }
            if (Physics.Raycast(ray, out hit, Time.deltaTime * speed, ignoreRaycastmask))
            {
                Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
                float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, rot, 0);
                maxBounce -= 1;
            }
        if (maxBounce == 0)
        {
            Instantiate(sparks, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
