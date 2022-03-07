using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PassageOfTime : MonoBehaviour
{
    public int[] d = { 1, 1, 1760 }; //start date, dd, mm, yr
    public GameObject[] disableWhenPaused;
    public TMP_Text dateString;
    public float tickSpeed = 1f;
    private string textFormat;

    // Start is called before the first frame update
    private void Start()
    {
        textFormat = dateString.text;
        Application.targetFrameRate = 60;
        StartCoroutine("GameLoop");
        pauseTime();
    }

    private void tickTime()
    {
        if (d[0] < 31 && d[1] % 2 == 1)
            d[0] += 1;
        else if (d[0] < 30 && d[1] % 2 == 0)
            d[0] += 1;
        else
        {
            d[1] += 1;
            d[0] = 1;
        }

        //February
        if (d[1] == 2 && d[0] > 28)
        {
            d[0] = 1;
            d[1] += 1;
        }

        if (d[1] > 12)
        {
            d[0] = 1;
            d[1] = 1;
            d[2]++;
        }
    }

    private string marchedTime()
    {
        string returnString = textFormat;
        string[] monthIndex = { "zeroMonth", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        returnString = returnString.Replace("month", monthIndex[d[1]]);
        returnString = returnString.Replace("day", d[0].ToString());
        returnString = returnString.Replace("year", d[2].ToString());
        ///print(returnString);
        return returnString;
    }

    private void pauseTime()
    {
        StopCoroutine("GameLoop");
        Time.timeScale = 0;
        GameObject.Find("$Storage").GetComponent<ResourceStorage>().gameIsPaused = true;
    }

    private IEnumerator GameLoop()
    {
        while (true)
        {
            dateString.text = marchedTime();
            tickTime();
            //dateString.text = marchedTime();
            yield return new WaitForSeconds(2);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space") && Time.timeScale > 0)
        {
            pauseTime();
        }
        else if (Input.GetKeyDown("space"))
        {
            StartCoroutine("GameLoop");
            Time.timeScale = 1;
            GameObject.Find("$Storage").GetComponent<ResourceStorage>().gameIsPaused = false;
            foreach (var obj in disableWhenPaused)
            {
                obj.SetActive(true);
            }
        }
    }
}