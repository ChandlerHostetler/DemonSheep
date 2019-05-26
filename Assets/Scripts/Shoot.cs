using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public int speed;
    public float coolDownTime;
    private float nextFiretime;
    public List<GameObject> bullets;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shoot();

        fire();
    }

    public void shoot()
    {

      
        Vector2 playerPos = player.transform.position;
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        Quaternion q = Quaternion.FromToRotation(Vector2.up, screenPos - playerPos);

        if (Input.GetMouseButtonDown(0))
        {
            if (transform.localScale.x < 0 && nextFiretime < Time.time)
            {
                nextFiretime = Time.time + coolDownTime;
                bullet = Instantiate(bullet, new Vector2(playerPos.x, playerPos.y), q);
                bullets.Add(bullet);

            }
            else if (nextFiretime < Time.time)
            {
                nextFiretime = Time.time + coolDownTime;
                bullet = Instantiate(bullet, new Vector2(playerPos.x, playerPos.y), q);
                bullets.Add(bullet);
     
            }

        }
     
   }

    public void fire()
    {
        //bullet.GetComponent<Rigidbody2D>().AddForce(bullet.GetComponent<Rigidbody2D>().transform.up * speed);
        foreach (GameObject bullet in bullets)
        {
            bullet.transform.Translate(Vector2.up * Time.deltaTime * speed); //this works?!?!?!?!?!?
        }
    }

}
