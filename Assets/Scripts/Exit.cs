using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] Sprite[] exitSpriteArray;
    [SerializeField] AudioClip winSFX;
    [SerializeField] float winVolume;
     
    [SerializeField] float rotationSpeed;

    public SpriteRenderer spriteRenderer;


    public void Awake()
    {
        spriteRenderer.sprite = exitSpriteArray[0];
    }

    private void Update()
    {
        this.transform.Rotate(0,0, -rotationSpeed * Time.deltaTime);
    }

    public void updateExitSprite()
    {
        if(GameSession.numSlices > 8)
        {
            spriteRenderer.sprite = exitSpriteArray[8];
        }
        spriteRenderer.sprite = exitSpriteArray[GameSession.numSlices];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tiger" && !collision.isTrigger && GameSession.numSlices >= FindObjectOfType<GameSession>().MAX_SLICES)
        {
            FindObjectOfType<GameSession>().Win();
            //AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position, winVolume);
        }
    }
}
