using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp2 : MonoBehaviour
{
    Light lamp;
    bool IsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        lamp = GetComponent<Light>();
        StartCoroutine(NyalaMati());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NyalaMati()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            IsOn = !IsOn;
            lamp.enabled = IsOn;    

        }
    }
}
