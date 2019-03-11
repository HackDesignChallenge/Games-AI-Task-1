using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public GameObject objectToVibrate;
    private Vibration vibration;
    // Start is called before the first frame update
    void Start()
    {
        objectToVibrate = GameObject.FindWithTag("MainCamera");
        vibration = objectToVibrate.GetComponent<Vibration>();
        vibration.StartShaking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
