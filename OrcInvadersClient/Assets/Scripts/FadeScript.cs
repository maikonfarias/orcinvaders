using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

    public float fadeScale = 0.9f;

	// Use this for initialization
	void Start () {
        Fade();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Fade()
    {
        var sprite = GetComponent<SpriteRenderer>();
        //sprite.material.color = new Color(sprite.material.color.r, sprite.material.color.g, sprite.material.color.b, sprite.material.color.a - 0.1f);
        sprite.material.color -= new Color(0, 0, 0, 0.1f);
        transform.localScale *= fadeScale;
        Invoke("Fade", 0.02f);
    }
}
