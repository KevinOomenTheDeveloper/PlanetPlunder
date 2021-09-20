using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelPickup : MonoBehaviour
{

    [Header("Parameters")]
    [Tooltip("Amount of health to heal on pickup")]
    public float fuelCount;

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
        Destroy(gameObject);
        fuelCount++;
        Debug.Log(fuelCount);

    }
}
