using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Camera cam;
    public float range = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractWithNPC();
        }
    }

    private void InteractWithNPC()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            NPC npc = hit.collider.GetComponent<NPC>();
            if (npc != null)
            {
                npc.Interact(); // Panggil fungsi interaksi pada NPC yang terkena raycast
            }
            else
            {
                Debug.Log("No NPC found at the interaction point.");
            }
        }
        else
        {
            Debug.Log("No object detected for interaction.");
        }
    }
}
