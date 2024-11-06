using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTrackerManager : MonoBehaviour
{
    public int dayCount;
    public Text dayCountTxt;

    private void Start()
    {
        dayCount = 0;
        UpdateDate();
    }

    public void UpdateDate()
    {
        dayCountTxt.text = "Day: " + dayCount;
    }
}
