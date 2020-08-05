using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int speed = 10;
    public int lifes = 3;
    public int bulletSpeed = 15;
    public Rigidbody2D bullet;
    public Boundary boundary;
    public float padding;

    public float fireRate;

    private Rigidbody2D rb;
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        boundary = new Boundary
        {
            xMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding,
            xMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding,
            yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding,
            yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding
        };            
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            //rotation не передается из объкта из фабрики, хотя установлен
            var rotation = Quaternion.Euler(0, 0, 90);
            Rigidbody2D bulletInstance = Instantiate(bullet, transform.position, rotation);
            bulletInstance.velocity = transform.TransformDirection(Vector2.up * bulletSpeed);
        }
    }

    void FixedUpdate()
    {       
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.velocity = movement * speed;

        rb.position = new Vector2
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax)
        );   
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Asteroid")
        {    
            Destroy(coll.transform.gameObject);
            lifes -= 1;
            if (lifes <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    //очень кривой вывод кол-ва жизней
    void OnGUI()
    {
        GUI.Label(new Rect(2, 40, 100, 150), "Lifes: " + lifes);
    }
}

public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}




