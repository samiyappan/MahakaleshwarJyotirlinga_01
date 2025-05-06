using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Grow : MonoBehaviour
{
    public List<MeshRenderer>growVinesMesh;
    public float timeToGrow=5;
    public float refreshRate = 0.05f;
    [Range(0,1)]
    public float minGrow = 0.2f;
    [Range(0,1)]
    public float maxGrow = 0.97f;

    private List<Material>growvinesmaterial = new List<Material>();
    private bool fullyGrown;
  

    void Start() 
    {
        for(int i= 0;i<growVinesMesh.Count;i++)
        {
            for(int j=0; j<growVinesMesh[i].materials.Length; j++)
            {
                if(growVinesMesh[i].materials[j].HasProperty("_Grow"))
                {
                    growVinesMesh[i].materials[j].SetFloat("_Grow",minGrow);
                    growvinesmaterial.Add(growVinesMesh[i].materials[j]);
                }

            }
        }
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for(int i=0;i<growvinesmaterial.Count;i++)
            {
                StartCoroutine(GrowVines(growvinesmaterial[i]));
            }
        }        
    }
    IEnumerator GrowVines( Material mat)
    {
        float growValue = mat.GetFloat("_Grow");
        if(!fullyGrown)
        {
            while(growValue <maxGrow)
            {
                growValue +=1/(timeToGrow/refreshRate);
                mat.SetFloat("_Grow",growValue);

                yield return new WaitForSeconds(refreshRate);
            }
        }
        else
        {

            while(growValue>minGrow)
            {
                growValue-= 1/(timeToGrow/refreshRate);
                mat.SetFloat("_Grow",growValue);

                yield return new WaitForSeconds(refreshRate);
            }

        }
        if(growValue>=maxGrow)
        {
            fullyGrown =true;
        }
        else
            fullyGrown = false;
        
    }   
    
}
