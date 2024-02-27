using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    public float materialduration = 2.0f;
    public float materialstrength;


    public void StartDuration()
    {
        StartCoroutine(dissolver());
    }
   public IEnumerator dissolver()
    {
        float elapseedTime = 0;
        Material dissolveMaterial = GetComponent<Renderer>().material;

        while (elapseedTime < materialduration) {
        
            elapseedTime += Time.deltaTime;

            materialstrength = Mathf.Lerp(0,1,elapseedTime/materialduration);
            dissolveMaterial.SetFloat("_Float",materialstrength);

            yield return null;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartDuration();
        }
    }
}
