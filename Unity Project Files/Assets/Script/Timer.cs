using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text counterText;
    public Text P1_Score;
    public Text P2_Score;
    public float timer = 10.0f;
    public bool endGame = false;
    public GameObject pinBall;
    public int p1S;
    public int p2S;
    

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>() as Text;
        P1_Score = GameObject.Find("P1_Score").GetComponent<Text>() as Text;
        P2_Score = GameObject.Find("P2_Score").GetComponent<Text>() as Text;
        pinBall = GameObject.Find("Pinball");
        
	}
	
	// Update is called once per frame
	void Update () {
        p1S = int.Parse(P1_Score.text);
        p2S = int.Parse(P2_Score.text);

        if (endGame == false)
        {
            timer -= Time.deltaTime;
            counterText.text = timer.ToString("f0");
        }
        else
        {
            if (p1S > p2S)
            {
                counterText.text = "Player 1 wins!";
            }

            if (p1S < p2S)
            {
                counterText.text = "Player 2 wins!";
            }

            if (p1S == p2S)
            {
                counterText.text = "It's a Tie!";
            }
        }
        
        if(timer < 0.0f)
        {
            endGame = true;
            counterText.text = "Time is up!";
            DestroyObject(pinBall);
        }
	}
}
