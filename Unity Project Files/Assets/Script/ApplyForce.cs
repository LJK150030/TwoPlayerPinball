using UnityEngine;
using System.Collections;

public class ApplyForce : MonoBehaviour {

    public  float       force = 1000.0f;
    public  Vector3     forceDirection = Vector3.forward;
    public  Vector3     offset;
    public  GameObject  p1RFlipper;
    public  GameObject  p1LFlipper;

    void Start()
    {
        p1RFlipper = GameObject.Find("P1_Flipper_R");
        p1LFlipper = GameObject.Find("P1_Flipper_L");
    }

	// Update is called once per frame
	void Update ()
    {
        //applies a force and rotation on the left flipper
        if (Input.GetKey(KeyCode.DownArrow))
        {
            p1LFlipper.GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position + offset);
        }
        else
        {
            p1LFlipper.GetComponent<Rigidbody>().AddForceAtPosition(-forceDirection.normalized * force, transform.position + offset);
        }

        //applies a force and rotation on the right flipper
        if (Input.GetKey(KeyCode.UpArrow))
        {
            p1RFlipper.GetComponent<Rigidbody>().AddForceAtPosition(forceDirection.normalized * force, transform.position - offset);
        }
        else
        {
            p1RFlipper.GetComponent<Rigidbody>().AddForceAtPosition(-forceDirection.normalized * force, transform.position - offset);
        }
    }
}
