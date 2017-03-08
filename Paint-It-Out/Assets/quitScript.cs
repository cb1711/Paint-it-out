using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class quitScript : MonoBehaviour {
    public Button urButton;
	// Use this for initialization
	void Start () {
        Button btn = urButton.GetComponent<Button>();
        btn.onClick.AddListener(quit);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
