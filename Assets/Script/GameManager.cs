using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winLosePanel;
    public string sceneName;
    public GameObject mouseLook;
    // Start is called before the first frame update
    void Start()
    {
        winLosePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DayTracker").GetComponent<DayTrackerManager>().dayCount <= 50)
        {
            if (GameObject.Find("Player").GetComponent<PlayerManager>().playerMoney >= 5000){
                //Display Win Panel
                mouseLook.GetComponent<MouseLook>().isInPosition = true;
                winLosePanel.SetActive(true);
                winLosePanel.transform.GetChild(0).GetComponent<Text>().text = "YOU WON!";
            }
            
        }

        if (GameObject.Find("DayTracker").GetComponent<DayTrackerManager>().dayCount > 50)
        {
            //Display Lose Panel
            mouseLook.GetComponent<MouseLook>().isInPosition = true;
            winLosePanel.SetActive(true);
            winLosePanel.transform.GetChild(0).GetComponent<Text>().text = "YOU LOST!";
        }
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
