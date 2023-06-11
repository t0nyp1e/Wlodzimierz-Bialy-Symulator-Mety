using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMan : MonoBehaviour
{
    public GameObject missileObj;
    public Transform spawnPoint;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject Missile = (GameObject)Instantiate(missileObj, spawnPoint.position, GameObject.FindWithTag("Orientation").transform.rotation);
        }
    }
}
