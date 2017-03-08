using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{

    
    public float CountdownFrom;
	public static float time;
	public Text CountdownText;

    void Start()
    {
        if (CountdownText == null)
        {
            Debug.LogError("STATUS INDICATOR: No text object referenced!");
        }
    }
    void Update()
    {
        time = CountdownFrom - Time.timeSinceLevelLoad;
        CountdownText.text = "Time left: " + time.ToString("0") + "s";

        if (time <= 20f)
        {
            TimeUp();
        }
    }

    void TimeUp()
    {
		addforcetoall.Score();
        SceneManager.LoadScene(2);
    }
}