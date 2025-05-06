using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerRun : MonoBehaviour
{
    //public SkinnedMeshRenderer skinnedMeshRenderer;
    public MeshRenderer skinnedMeshRenderer;
   public float erodeRate = 0.03f;
   public float erodeRefereshRate = 0.01f;
   public float erodeDeley = 1.25f;


   public void Start()
   {
    StartCoroutine(ErodeObject());
   }

   IEnumerator ErodeObject()
   {
    yield return new WaitForSeconds(erodeDeley);

    float t = 0;
    while(t<1)
    {
        t+=erodeRate;
        skinnedMeshRenderer.material.SetFloat("_Erode",t);
        yield return new WaitForSeconds(erodeRefereshRate);

    }
   }

}
