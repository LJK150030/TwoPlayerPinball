using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{

    public float durration = 0.0f;
    public float defaultDurration = 15.0f;
    public float respawnTime;
    public int selection;
    public bool pickupUsed = false;
    public GameObject pinBall;
    public GameObject PU_Squash;
    public GameObject PU_Rubber;
    public Material original;
    public Material squash;
    public Material rubber;
    public Quaternion rotation = Quaternion.identity;

    void OnTriggerEnter(Collider col)
    {
        pickupUsed = true;
        if (selection <= durration)
        {
            setToRubber();
            PU_Rubber.GetComponent<Renderer>().enabled = false;
            PU_Rubber.transform.position = new Vector3(10.0f, 10.0f, -10.0f);
        }

        if (selection > durration)
        {
            setToSquash();
            PU_Squash.GetComponent<Renderer>().enabled = false;
            PU_Rubber.transform.position = new Vector3(-10.0f, -10.0f, -10.0f);
        }
        durration = defaultDurration;
    }

    void setToRubber()
    {
        pinBall.GetComponent<Renderer>().material = rubber;
        pinBall.GetComponent<Rigidbody>().mass = 0.1f;
    }

    void setToSquash()
    {
        pinBall.GetComponent<Renderer>().material = squash;
        pinBall.GetComponent<Rigidbody>().mass = 5.0f;
    }

    void setToOriginal()
    {
        pinBall.GetComponent<Renderer>().material = original;
        pinBall.GetComponent<Rigidbody>().mass = 1.0f;
    }

    void select()
    {
        selection = Random.Range(0, 20);
        if (selection <= 10)
        {

            PU_Rubber.GetComponent<Renderer>().enabled = true;
            PU_Rubber.transform.position = new Vector3(Random.Range(-14, 14), 11.0f, 28.0f);
        }

        if (selection > 10)
        {
            PU_Squash.GetComponent<Renderer>().enabled = true;
            PU_Squash.transform.position = new Vector3(Random.Range(-14, 14), 11.0f, 28.0f);
        }
        durration = defaultDurration;
    }

    void Start()
    {
        rotation.eulerAngles = new Vector3(45.0f, 45.0f, 45.0f);
        respawnTime = Random.Range(15, 45);
    }

    // Update is called once per frame
    void Update()
    {

        //Counts down the respawnTime and durration of the power up
        if (pickupUsed.Equals(false))
        {
            respawnTime -= Time.deltaTime;
        }
        
        if (pickupUsed.Equals(true))
        {
            durration -= Time.deltaTime;
            respawnTime = Random.Range(15, 45);
        }

        //When the pickup finishes
        if (durration <= 0.0)
        {
            setToOriginal();
            pickupUsed = false;
            //When to respawn a new pickup
            if (respawnTime <= 0.0f)
            {
                select();
            }
        }
    }
}
