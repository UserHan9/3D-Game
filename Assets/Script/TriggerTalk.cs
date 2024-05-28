using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TriggerTalk : MonoBehaviour
{
    public Canvas canvas;
    public TextMeshProUGUI textMeshProUGUI;

    // Ketika collider memasuki objek
    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang memasuki collider adalah Player
        if (other.CompareTag("Player"))
        {
            // Tampilkan teks pada TextMeshProUGUI
            textMeshProUGUI.text = "Bicaralah dengan NPC (Capsule)";
            canvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cek apakah objek yang keluar dari collider adalah Player
        if (other.CompareTag("Player"))
        {
            // Nonaktifkan canvas
            canvas.enabled = false;
            // Kosongkan teks pada TextMeshProUGUI
            textMeshProUGUI.text = "";
        }
    }

}