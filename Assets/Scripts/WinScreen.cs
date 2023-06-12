using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeLeftText;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameSession.timeLeft);
        timeLeftText.text = GameSession.timeLeft.ToString("F2");
    }

}
