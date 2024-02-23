using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light light;
    private bool islighton = false;
    private bool isSwitching = false; // variabel untuk menandai apakah sedang dalam proses menyalakan atau mematikan
    public AudioSource suara;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        light.enabled = false;
        suara = GetComponent<AudioSource>();
        suara.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isSwitching)
        {
            isSwitching = true; // menandai proses switch sedang berjalan
            islighton = !islighton;

            if (islighton)
            {
                light.enabled = true;
                StartCoroutine(DelaySwitching(true));
            }
            else
            {
                StartCoroutine(DelaySwitching(false));
            }
        }
    }

    IEnumerator DelaySwitching(bool playSound)
    {
        if (playSound)
            suara.Play(); // Memutar suara hanya jika memang harus menyalakan lampu
        yield return new WaitForSeconds(2.0f); // delay selama 2 detik sebelum switch berikutnya dapat dilakukan
        light.enabled = islighton; // Menyalakan atau mematikan lampu setelah delay
        isSwitching = false; // menandai bahwa proses switch sudah selesai
    }
}
