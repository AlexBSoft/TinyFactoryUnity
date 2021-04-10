using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    public bool ToggleTogglerGM = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroy");
        if(ToggleTogglerGM)
            GameObject.Find("GameManager").GetComponent<GameManager>().DeleterToggle();
        else
            GameObject.Find("GameManager").GetComponent<GameManager>().DeleterToggle2();
        Destroy(collision.gameObject);
       
    }

}
