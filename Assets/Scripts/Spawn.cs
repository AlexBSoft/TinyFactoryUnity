using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] ItemList;
    private int random;


    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            random = Random.Range(0, ItemList.Length);
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        Instantiate(ItemList[random], transform.position, Quaternion.identity);
    }

}
