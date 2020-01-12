using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    private Transform myTransform;

    private Rigidbody rb;

    public bool placeOnSurface = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (placeOnSurface)
            GravityAttractor.sharedInstance.PlaceOnSurface(rb);
        else            
            GravityAttractor.sharedInstance.Attract(myTransform);
    }
}
