using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI slicesCollectedText;

    // Start is called before the first frame update
    void Start()
    {
        slicesCollectedText.text = GameSession.numSlices.ToString();
    }
}
