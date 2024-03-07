using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToForest : MonoBehaviour
{

    // Ketika objek masuk ke dalam collider
    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
           
            SceneManager.LoadScene("Forest");
        }
        else
        {
            Debug.Log("scene forest tidak ada");
        }
    }
}
