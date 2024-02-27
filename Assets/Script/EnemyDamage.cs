using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float health = 100f;
    public float deathFadeSpeed = 0.5f; // Kecepatan perubahan nilai untuk efek hilang
    public Renderer objectRenderer; // Komponen Renderer untuk mengatur material
    public Material deathMaterial; // Material untuk efek hilang
    private Collider enemyCollider; // Collider musuh
    private bool isDead = false; // Status apakah musuh sudah mati atau belum

    private float surfaceInputValue = 0f; // Nilai float untuk input surface pada shader

    private void Start()
    {
        // Pastikan Anda mendapatkan komponen Renderer dan Collider jika belum diset
        if (objectRenderer == null)
            objectRenderer = GetComponent<Renderer>();

        enemyCollider = GetComponent<Collider>();
    }

    public void TakeDamage(float amount)
    {
        if (!isDead) // Hanya jika musuh belum mati
        {
            health -= amount;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true; // Set status menjadi mati

        // Set nilai input surface pada shader ke 0
        surfaceInputValue = 0f;

        // Pastikan material kematian telah ditetapkan
        if (deathMaterial != null)
        {
            // Set material objek menjadi material kematian
            objectRenderer.material = deathMaterial;

            // Mematikan collider musuh
            if (enemyCollider != null)
                enemyCollider.enabled = false;

            // Memulai efek hilang
            StartCoroutine(FadeOutMaterial());
        }
        else
        {
            Debug.LogError("Death material is not assigned!");
        }
    }

    IEnumerator FadeOutMaterial()
    {
        // Perlahan-lahan meningkatkan nilai input surface dari 0 hingga 1
        while (surfaceInputValue < 1f)
        {
            surfaceInputValue += deathFadeSpeed * Time.deltaTime;
            surfaceInputValue = Mathf.Clamp01(surfaceInputValue);

            // Set nilai input surface pada material
            objectRenderer.material.SetFloat("_Float", surfaceInputValue); // Sesuaikan dengan nama input float yang digunakan dalam shader

            yield return null;
        }

        // Setelah selesai, hancurkan objek
        Destroy(gameObject);
    }
}
