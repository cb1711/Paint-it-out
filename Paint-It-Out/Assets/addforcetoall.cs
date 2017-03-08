using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class addforcetoall : MonoBehaviour
{
    public  GameObject TestCube;
	public static int ColumnLength = 8;
	public static int RowHeight = 10;
	public static GameObject[,] cubeArray;
	public static System.Random rnd1;
	public static int direction = 0;
	public static int [] Rowlength;
	public static int valid_touch=0;
	public static float calw=15/183*Screen.width;
	public static float calh=15/292*Screen.height;
	public static int painted = 0;
	public static int topaint=0;
	public static int strokes=0;
	public static int[] coordinates; 
	static void paint(float x, float y)
    {
        boxnum(x, y);
        if (Rowlength[coordinates[0]] > coordinates[1] && coordinates[1] >= 0)
        {
            if (cubeArray[coordinates[0], coordinates[1]].GetComponent<Renderer>().material.color != Color.red)
            {
                cubeArray[coordinates[0], coordinates[1]].GetComponent<Renderer>().material.color = Color.red;
                painted = painted + 1;
                print(painted);

                //}
            }
        }
        else
        {
            valid_touch = 0;
        }
    }
    void finished()
	{
		if (painted == topaint) {
			Score();

			SceneManager.LoadScene(2);
		
		}
	}
	static void boxnum(float x, float y)
    {

        coordinates[0] = (int)(x / Screen.width * ColumnLength);
        coordinates[1] = (int)(y / Screen.width * 8) - 1;
    }
    void Awake()
    {
        painted = 0;
        topaint = 0;
        strokes = 0;

        Rowlength = new int[ColumnLength];
        cubeArray = new GameObject[ColumnLength, RowHeight];
        rnd1 = new System.Random();
        for (int i = 0; i < ColumnLength; i++)
        {
            Rowlength[i] = rnd1.Next(1, RowHeight);
            topaint += Rowlength[i];
            for (int j = 0; j < Rowlength[i]; j++)
            {
                cubeArray[i, j] = (GameObject)Instantiate(TestCube);
                cubeArray[i, j].transform.position = new Vector3(i + .5f * i, 10 * j + 10, 0);



            }
            print(topaint);
        }
    }
    void Start()
    {
		coordinates = new int[2];
    }
	static int optimum(int l, int r, int bottom,int []planks)
	{
		if (r - l == 1) return 1;
		var bottomNew = Int32.MaxValue;

		for (var i = l; i < r; i++)
		{
			bottomNew = Math.Min(bottomNew, planks[i]);
		}
		var strokes = bottomNew - bottom;
		var lNew = 0;
		var painted = true;

		for (var i = l; i <= r; i++)
		{
			if (painted && i < r && planks[i] > bottomNew)
			{
				lNew = i;
				painted = false;
			}
			else if (!painted && (i == r || planks[i] == bottomNew))
			{
				strokes += optimum(lNew, i, bottomNew,planks);
				painted = true;
			}
		}

		return Math.Min(r - l, strokes); ;
	}
	public  static int Score()
	{
		int optim = optimum (0,8,0,Rowlength);
		int ss = (int)((painted * 1.0 / topaint * (countdown.time + optim * 1.0 / (1 + strokes))));
		print ("score"+ss);
		PlayerPrefs.SetInt ("Score", ss);
		return ss;

	}

    // Update is called once per frame
	void Update()
	{
		
		if (Input.touchCount >0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			valid_touch = 1;
			direction = 0;
			strokes = strokes + 1;
			paint (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y);
		} else if (Input.touchCount >0 && Input.GetTouch (0).phase == TouchPhase.Moved && valid_touch == 1) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			if (direction == 0) {
				if (touchDeltaPosition.x < 5f && touchDeltaPosition.x > -5f && touchDeltaPosition.y < -5f)
					direction = -1;//-1 represents down
				else if (touchDeltaPosition.x < 5f && touchDeltaPosition.x > -5f && touchDeltaPosition.y > 5f)
					direction = 1;//+1 represents up
				else if (touchDeltaPosition.x > 5f && touchDeltaPosition.y > -5f && touchDeltaPosition.y < 5f)
					direction = 2;//+2 represents right
				else if (touchDeltaPosition.x < -5f && touchDeltaPosition.y > -5f && touchDeltaPosition.y < 5f)
					direction = -2;//-2 represents left
				else if(touchDeltaPosition.x>5f && touchDeltaPosition.y>5f) {
					valid_touch = 0;
				}
				else if(touchDeltaPosition.x<-5f && touchDeltaPosition.y>5f) {
					valid_touch = 0;
				}
				else if(touchDeltaPosition.x>5f && touchDeltaPosition.y<-5f) {
					valid_touch = 0;
				}
				else if(touchDeltaPosition.x<-5f && touchDeltaPosition.y<-5f) {
					valid_touch = 0;
				}
			} 
			else {
				int temp = 0;
				if (touchDeltaPosition.x < 5f && touchDeltaPosition.x > -5f && touchDeltaPosition.y < -5f)
					temp = -1;//-1 represents down
				else if (touchDeltaPosition.x < 5f && touchDeltaPosition.x > -5f && touchDeltaPosition.y > 5f)
					temp = 1;//+1 represents up
				else if (touchDeltaPosition.x > 5f && touchDeltaPosition.y > -5f && touchDeltaPosition.y < 5f)
					temp = 2;
				else if (touchDeltaPosition.x < -5f && touchDeltaPosition.y > -5f && touchDeltaPosition.y < 5f)
					temp = -2;//2 represents left
				else if(touchDeltaPosition.x>5f && touchDeltaPosition.y>5f) {
					valid_touch = 0;
				}
				else if(touchDeltaPosition.x<-5f && touchDeltaPosition.y>5f) {
					valid_touch = 0;
				}
				else if(touchDeltaPosition.x>5f && touchDeltaPosition.y<-5f) 
					valid_touch = 0;
				
				else if(touchDeltaPosition.x<-5f && touchDeltaPosition.y<-5f)
					valid_touch = 0;
				

				if (temp != direction && temp!=0) 
					valid_touch = 0;
			}
			if (valid_touch == 1) {
				paint (Input.GetTouch (0).position.x, Input.GetTouch (0).position.y);
			
			
			}
		} 
		finished ();
	}

}
