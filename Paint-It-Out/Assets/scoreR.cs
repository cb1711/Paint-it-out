using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreR : MonoBehaviour {
	int score,highscore;
	public Text Score, HighScore;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
		StoreHighscore (score);
		highscore = PlayerPrefs.GetInt ("highscore");
		Score.text = "Score\n"+ score.ToString();
		HighScore.text = "HighScore\n"+highscore.ToString();


	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
    void StoreHighscore(int newHighscore)
    {
        int oldHighscore = PlayerPrefs.GetInt("highscore", 0);
        if (newHighscore > oldHighscore)
            PlayerPrefs.SetInt("highscore", newHighscore);
    }
}
