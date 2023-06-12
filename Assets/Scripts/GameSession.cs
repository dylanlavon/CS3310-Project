using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI sliceText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject tiger;

    static public float timeLeft;
    static public int numSlices;

    public bool isTimerOn = false;

    public int MAX_SLICES = 8;
    public bool isExitOpen = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level")
        {
            timeLeft = 90;
            numSlices = 0;
        }     
        sliceText.text = numSlices.ToString();
    }

    void Update()
    {
        if(Input.anyKeyDown && !isExitOpen)
        {
            isTimerOn = true;
        }
        if(isTimerOn && FindObjectOfType<PlayerMovement>().allowMovement)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                // Remove player control and revert player animation to idle
                gameOver();
            }
        }
    }

    void gameOver()
    {
        Debug.Log("Time is up!");
        timeLeft = 0;
        isTimerOn = false;
        tiger.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        FindObjectOfType<Animator>().SetBool("isRunning", false);
        FindObjectOfType<SceneMan>().LoadLose();
    }

    public void Win()
    {
        isTimerOn = false;
        Debug.Log(timeLeft);
        tiger.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        FindObjectOfType<Animator>().SetBool("isRunning", false);
        FindObjectOfType<SceneMan>().LoadWin();
    }

    void updateTimer(float currentTime)
    {
        float seconds = currentTime;
        timeText.text = seconds.ToString("F2");
    }

    public void AddSlice()
    {
        numSlices++;
        sliceText.text = numSlices.ToString();

        FindObjectOfType<Exit>().updateExitSprite();

        if (numSlices >= MAX_SLICES)
        {
            isExitOpen = true;
        }
    }
}
