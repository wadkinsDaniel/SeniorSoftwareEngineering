using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotDogSpawn : MonoBehaviour {
    public List<Transform> locations = new List<Transform>();
    
	// Use this for initialization
	void Start () {
        gameObject.transform.position = locations[Random.Range(0, locations.Count)].position;
	}
	
	
}
