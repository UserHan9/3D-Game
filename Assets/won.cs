using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class won : MonoBehaviour
{
    private bool gameEnded = false;

    // Update is called once per frame
    void Update()
    {
        // Cek apakah permainan sudah berakhir
        if (!gameEnded && GameObject.FindWithTag("Finish") == null)
        {
            // Panggil fungsi untuk menang
            GameWon();
        }
    }

    void GameWon()
    {
        // Tambahkan logika di sini untuk menangani situasi ketika permainan dimenangkan
        Debug.Log("Game Won!");
        gameEnded = true;
        SceneManager.LoadScene("Menang");
    }
}
