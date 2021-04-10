using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterToggler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.CenterToggle();
        
    }
}
