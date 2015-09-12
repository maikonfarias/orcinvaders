using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public GameObject explosionClone;
    public GameObject childSprite;

    int bounces = 0;
	
	void Start () {
	
	}
	
	
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "Bullet")
        {
            return;
        }

        if (other.tag == "BouncyWall" && bounces == 0)
        {
            Bounce();             
            return;
        }
        var spriteImage = childSprite.GetComponent<SpriteRenderer>().sprite;


        var newObj = (GameObject)Instantiate(explosionClone, childSprite.transform.position, childSprite.transform.rotation);
        newObj.GetComponent<SpriteRenderer>().sprite = spriteImage;

        Destroy(this.gameObject);        
    }

    private void Bounce()
    {
        bounces++;
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x * -1, GetComponent<Rigidbody2D>().velocity.y);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z * -1, transform.rotation.w);
    }


}
