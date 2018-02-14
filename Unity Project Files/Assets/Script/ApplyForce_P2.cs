using UnityEngine;
using System.Collections;

public class ApplyForce_P2 : MonoBehaviour
{

    public float force = 1000.0f;
    public Vector3 forceDirection = Vector3.forward;
    public Vector3 offset;
    public GameObject p2RFlipper;
    public GameObject p2LFlipper;

    void Start()
    {
        p2RFlipper = GameObject.Find("P2_Flipper_R");
        p2LFlipper = GameObject.Find("P2_Flipper_L");
    }

    // Update is called once per frame
    void Update()
    {
        //applies a force and rotation on the left flipper
        if (!Input.GetKey(KeyCode.W))
        {
            p2LFlipper.GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);
        }
        else
        {
            p2LFlipper.GetComponent<Rigidbody>().AddForceAtPosition(-forceDirection.normalized * force, transform.position + offset);
        }

        //applies a force and rotation on the right flipper
        if (!Input.GetKey(KeyCode.S))
        {
            p2RFlipper.GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position - offset);
        }
        else
        {
            p2RFlipper.GetComponent<Rigidbody>().AddForceAtPosition(-forceDirection.normalized * force, transform.position - offset);
        }
    }
}
