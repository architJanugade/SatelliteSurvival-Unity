using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : GravityBody
{
    public SphereCollider SphereCol;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        this.enabled = false; 
        GetComponent<GravityBody>().enabled = false;
        SphereCol.isTrigger = true;
        Invoke("DestroyMe", 4f);
    }
    public void DestroyMe()
    {
        this.enabled = true;
        GetComponent<GravityBody>().enabled = true;
        SphereCol.isTrigger = false;    
        ObjectPooler.sharedInstace.BacktoList(gameObject);
        

    }
}
