using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P2_Goal : MonoBehaviour
{

    public GameObject pinBall;
    public Text p1Score;
    public Quaternion rotation = Quaternion.identity;
    public int p1S = 0;

    void start()
    {
        pinBall = GameObject.Find("Pinball");
        p1Score = GameObject.Find("P1_Score").GetComponent<Text>() as Text;
        rotation.eulerAngles = new Vector3(0, 180, 0);

    }

    void OnTriggerEnter(Collider other)
    {
        pinBall.transform.position = new Vector3(Random.Range(-14, 14), 11.0f, 28.0f);
        pinBall.transform.rotation = rotation;
        p1S++;
        p1Score.text = p1S.ToString();
    }
}
