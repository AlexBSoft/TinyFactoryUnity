using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{

    public Sprite[] frames;
    public float fps = 10f;

    public bool paused = false;

    SpriteRenderer spriteR;

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!paused){
            float index = ( Time.time * fps ) % frames.Length;
            spriteR.sprite = frames[(int)index];
        }
    }

    public void TogglePause(){
        paused = !paused;
    }
}
