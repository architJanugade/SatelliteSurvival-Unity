using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : GravityBody
{
    public BoxCollider BoxCol;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        BoxCol.enabled = false;
        this.enabled = false; 
        GetComponent<GravityBody>().enabled = false;
        Invoke("DestroyMe", 4f);
    }
    public void DestroyMe()
    {
        BoxCol.enabled = true;
        this.enabled = true;
        GetComponent<GravityBody>().enabled = true;
        ObjectPooler.sharedInstace.BacktoList(gameObject);
        

    }
}
