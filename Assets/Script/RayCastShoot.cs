using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public Camera fpscam;
    public float FireRate = 10f;
    public float NextFireRate = 0f;
    public GameObject bulletEffect;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= NextFireRate)
        {
            NextFireRate = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            EnemyDamage enemy = hit.transform.GetComponent<EnemyDamage>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);

                // Memunculkan efek hit jika peluru mengenai target
                GameObject hitGO = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitGO, 0.5f); // Hancurkan efek hit setelah 0.5 detik
            }
        }
        else
        {
            // Jika tidak ada tabrakan, kita buat efek peluru yang terbang
            GameObject bulletGO = Instantiate(bulletEffect, fpscam.transform.position, fpscam.transform.rotation);
            Destroy(bulletGO, 2f); // Hancurkan efek peluru setelah 2 detik
        }
    }
}
