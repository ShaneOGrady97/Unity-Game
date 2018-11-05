using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCountdown : MonoBehaviour {

    public GameObject CarController;

	
	void Start () {
        CarController.GetComponent<CarControl>().enabled = true; // Car controller script made active on F1 object
    }
	
	
}
