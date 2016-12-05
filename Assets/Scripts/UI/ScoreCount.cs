using UnityEngine;
using System.Collections;

public class ScoreCount : MonoBehaviour
{
    static int score = 0;
    public float timer = 180; //3min
    string strTimer;

    void OnGUI()
    {
        score = PlayerManager.Instance.PeopleKilled;
        GUI.Label(new Rect(10, 10, 100, 20), ("Victims: " + score));

        //GUI.Label(new Rect(10, 10, 250, 100), strTimer);
        GUI.Label(new Rect(100, 10, 200, 20), ("Time Until Daylight: " + (timer - Time.time) ));
    }
}
