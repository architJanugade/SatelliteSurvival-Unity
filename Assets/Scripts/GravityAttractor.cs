using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    public static GravityAttractor sharedInstance;
    private float gravity = -10;
    private SphereCollider col;
    private void Awake()
    {
        sharedInstance = this;
        col = GetComponent<SphereCollider>();
    }
    public void Attract (Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position) .normalized;
        Vector3 bodyup = body.up ;
        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);
        Quaternion targetRot = Quaternion.FromToRotation(body.up, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation , targetRot , 50 * Time.deltaTime);
    }
    public void PlaceOnSurface(Rigidbody body)
    {
        body.MovePosition((body.position - transform.position).normalized * (transform.localScale.x * col.radius));

        Vector3 gravityUp = (body.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.FromToRotation(body.transform.up, gravityUp) * body.rotation;
        body.MoveRotation(Quaternion.Slerp(body.rotation, targetRotation, 20f * Time.deltaTime));
    }
}
