using UnityEngine;

public class Die : MonoBehaviour
{
    public float fadeSpeed = 0.5f; // Kecepatan hilangnya material
    private float fadeAmount = 0f; // Jumlah pengurangan material
    private Renderer objectRenderer; // Renderer objek
    private Material material; // Material objek
    private bool isDying = false; // Apakah objek sedang mati

    private void Start()
    {
        // Mendapatkan komponen Renderer dari objek
        objectRenderer = GetComponent<Renderer>();

        // Mendapatkan material dari objek
        material = objectRenderer.material;
    }

    private void Update()
    {
        // Jika objek sedang mati
        if (isDying)
        {
            // Mengurangi nilai fadeAmount secara perlahan
            fadeAmount += fadeSpeed * Time.deltaTime;

            // Memastikan nilai fadeAmount tidak melebihi 1
            fadeAmount = Mathf.Clamp01(fadeAmount);

            // Menetapkan nilai input surface pada material
            material.SetFloat("_SurfaceAmount", fadeAmount);

            // Jika nilai telah mencapai 1 (material telah hilang sepenuhnya)
            if (fadeAmount >= 1f)
            {
                // Hapus objek dari permainan
                Destroy(gameObject);
            }
        }
    }

    public void StartDeath()
    {
        // Mengatur status mati menjadi true
        isDying = true;
    }
}
