using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Destroy(gameObject);
        Debug.Log(GameObject.Find("GameManager").GetComponent<fuelManager>().fuelCounter);

    }
}
