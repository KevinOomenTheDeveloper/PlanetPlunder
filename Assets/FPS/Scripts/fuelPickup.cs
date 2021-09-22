using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;

public class fuelPickup : MonoBehaviour
{
    public int fuelValue;

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
        //GameObject.Find("GameManager").GetComponent<fuelManager>().fuelCounter += fuelValue;
        PickupEvent evt = Events.PickupEvent;
        evt.Pickup = this.gameObject;
        evt.Fuel = fuelValue;
        //evt.RemainingFuelCount = enemiesRemainingNotification;
        EventManager.Broadcast(evt);
        GameObject.Destroy(this.gameObject);
        //Debug.Log(GameObject.Find("GameManager").GetComponent<fuelManager>().fuelCounter);

    }
}
