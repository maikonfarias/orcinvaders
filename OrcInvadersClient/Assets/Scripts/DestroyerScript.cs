using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			//Debug.Break();
			Application.LoadLevel(2);
			return;
		}

		if (other.gameObject.transform.parent) 
		{
			Destroy (other.gameObject.transform.gameObject);
		} else {
			Destroy(other.gameObject);
		}
	}
}
