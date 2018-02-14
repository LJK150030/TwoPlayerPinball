using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour {

    public  float       force       = 1000.0f;
    public  float       forceRadius = 1.0f;
    public  ForceMode   forceMode;

    //When the ball hits the cylynder
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, forceRadius);
        foreach (Collider hit in colliders) //returns a list a array coliders
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, forceRadius, 0.0f, forceMode);
            }
        }
    }
}
