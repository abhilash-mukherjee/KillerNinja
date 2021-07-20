using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TImer : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    bool isTimerRunning = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0){
            isTimerRunning = true;
        }
        else{
            isTimerRunning = false;
        }

        if(isTimerRunning){
        
        time = time - Time.deltaTime;
        int secondTime = (int) time % 60;
        gameObject.GetComponent<Text>().text = "0:0" +  secondTime.ToString();
        }
        else
        {
            gameObject.GetComponent<Text>().text = "Game Over";
        }
    }
}
