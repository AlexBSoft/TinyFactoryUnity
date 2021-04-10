using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObject : MonoBehaviour
{

    SpriteRenderer spriteR;
    Sprite btnOk;
    [Range(1, 2)]
    public int BtnID;
    public Sprite btnClicked;

    AudioSource audioData;


    private void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        //Debug.Log("Mouse is over GameObject.");
    }

    private void OnMouseDown() {
        Debug.Log("Mouse is clicked.");
        spriteR.sprite = btnClicked;
        audioData.Play(0);

        GameObject.Find("GameManager").GetComponent<GameManager>().ClickButton(BtnID);
    }

    private void OnMouseUp() {
        spriteR.sprite = btnOk;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        btnOk = spriteR.sprite;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
