using UnityEngine;
using System.Collections;

public class SelfAnimationScript : MonoBehaviour {

    public bool keepRotating = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (keepRotating)
        {
            transform.Rotate(0, 0, 30);
        }
	}
}
