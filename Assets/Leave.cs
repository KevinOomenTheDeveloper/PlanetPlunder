using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class Leave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (GameObject.Find("ObjectivePickupItem").GetComponent<ObjectivePickupItem>().EnoughFuel)
            GameObject.Find("ObjectivePickupItem").GetComponent<ObjectivePickupItem>().Win();
    }
}
