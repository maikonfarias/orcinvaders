using UnityEngine;
using System.Collections;

public class SelfDestroyScript : MonoBehaviour {

    public float time = 5f;
	
	void Start () {
        Destroy(gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
