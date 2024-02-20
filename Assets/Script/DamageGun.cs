using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGun : MonoBehaviour
{
    public float damageGun;
    public float BulletRange;
    public GameObject particleEffect; // Particle effect object to be assigned in the inspector
    private Transform playerTransform; // Player's transform

    // Start is called before the first frame update
    void Start()
    {
        // Assuming player is the parent object, otherwise adjust accordingly
        playerTransform = transform.parent; // Assuming the player is the parent object
    }

    // Update is called once per frame
    public void shoot()
    {
        Ray gunRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(gunRay, out RaycastHit hitInfo, BulletRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out Entity enemy))
            {
                enemy.Health -= 1;
            }

            // Spawn particle effect from player's position
            Instantiate(particleEffect, playerTransform.position, Quaternion.identity);
        }
    }
}
