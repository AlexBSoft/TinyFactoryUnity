using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveObject : MonoBehaviour
{

    private void Start()
    {
        GetComponent<Animation>().Play("MoveObjectAnimation");
    }


    
}
