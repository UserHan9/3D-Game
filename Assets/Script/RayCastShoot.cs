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
    private Animator anim;

    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= NextFireRate)
        {
            anim.SetTrigger("nembak"); // Mengatur trigger untuk memulai animasi tembakan
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
    }
}

