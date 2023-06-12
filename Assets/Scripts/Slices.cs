using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Slices : MonoBehaviour
{
    [SerializeField] AudioClip nomSFX;
    [SerializeField] float nomVolume;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tiger" && !collision.isTrigger)
        {
            FindObjectOfType<GameSession>().AddSlice();
            AudioSource.PlayClipAtPoint(nomSFX, Camera.main.transform.position, nomVolume);
            Destroy(gameObject);
        }
    }
}
