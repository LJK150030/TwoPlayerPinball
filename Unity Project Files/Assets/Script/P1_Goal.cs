using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class P1_Goal : MonoBehaviour {

    public GameObject pinBall;
    public Text p2Score;
    public Quaternion rotation = Quaternion.identity;
    public int p2S = 0;

    void start()
    {
        pinBall = GameObject.Find("Pinball");
        p2Score = GameObject.Find("P2_Score").GetComponent<Text>() as Text;
        rotation.eulerAngles = new Vector3(0, 180, 0);

    }

    void OnTriggerEnter (Collider other)
    {
        pinBall.transform.position = new Vector3(Random.Range(-14, 14), 11.0f, 28.0f);
        pinBall.transform.rotation = rotation;
        p2S++;
        p2Score.text = p2S.ToString();
    }
}
