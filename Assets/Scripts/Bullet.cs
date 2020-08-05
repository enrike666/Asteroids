using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Score score;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Asteroid")
        {        
            Destroy(coll.transform.gameObject);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
