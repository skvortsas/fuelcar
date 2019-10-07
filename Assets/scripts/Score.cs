using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText, topScoreText;
    private float timer, timerToStart;
    public carMovement car;

	// Update is called once per frame
	void Update () {
        timerToStart += Time.deltaTime * 10;

        if (timerToStart > 10)
        {

            car.DataScore = timer.ToString("0");

            if (!car.is_walled && !car.is_lack)
            {
                timer += Time.deltaTime * 10;
            }

            scoreText.text = "score: " + timer.ToString("0");

            topScoreText.text = "top score: " + PlayerPrefs.GetInt("TopScore");
        }
	
	}
}
