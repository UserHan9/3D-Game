using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampu : MonoBehaviour
{
    Light lamp;
    bool isOn = false;

    void Start()
    {
        lamp = GetComponent<Light>();
        StartCoroutine(ToggleLight());
    }

    IEnumerator ToggleLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); // Tunggu 1 detik

            // Ganti status lampu
            isOn = !isOn;
            lamp.enabled = isOn;

            // Debug.Log(isOn ? "Lampu hidup" : "Lampu mati");
        }
    }
}
