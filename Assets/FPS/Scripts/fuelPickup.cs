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
        GameObject.Find("GameManager").GetComponent<fuelManager>().fuelCounter += fuelValue;
        EnemyKillEvent evt = Events.Fue;
        evt.Enemy = enemyKilled.gameObject;
        evt.RemainingEnemyCount = enemiesRemainingNotification;
        EventManager.Broadcast(evt);
        Destroy(gameObject);
        Debug.Log(GameObject.Find("GameManager").GetComponent<fuelManager>().fuelCounter);

    }
}
