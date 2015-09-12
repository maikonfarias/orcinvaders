using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public GameObject explosionClone;
    GameObject mainCamera;

	void Start () {
        mainCamera = GameObject.Find("Main Camera");
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -100));
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            return;
        }

        if (other.tag == "Base" || other.tag == "Player")
        {
            mainCamera.GetComponent<MainScript>().ReduceScore(10);
        }
        else
        {
            mainCamera.GetComponent<MainScript>().AddScore(1);
        }

        var spriteImage = GetComponent<SpriteRenderer>().sprite;

        var newObj = (GameObject)Instantiate(explosionClone, transform.position, Quaternion.identity);
        newObj.GetComponent<SpriteRenderer>().sprite = spriteImage;

        Destroy(this.gameObject);
    }
}
