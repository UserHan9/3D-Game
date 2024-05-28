using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public GameObject Gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Recoil());
        }
    }

   IEnumerator Recoil()
    {
        Gun.GetComponent<Animator>().Play("Recoil");
        yield return new WaitForSeconds(0.20f);
        Gun.GetComponent<Animator>().Play("idlea");
    }
}
