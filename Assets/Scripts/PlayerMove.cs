using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject player;
    public int speed;
    public List<BoxCollider> walls;

    // Start is called before the first frame update
    void Start()
    {
        foreach (BoxCollider wall in walls)
        {
            float xRange = UnityEngine.Random.Range(-wall.bounds.extents.x, wall.bounds.extents.x);
            float yRange = UnityEngine.Random.Range(-wall.bounds.extents.y, wall.bounds.extents.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
        foreach (BoxCollider wall in walls)
        {
            if (wall.bounds.Contains(player.transform.position))
            {
                player.transform.position = wall.bounds.ClosestPoint(player.transform.position);
            }
        }
    }

    public void move()
    {
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        player.transform.Translate(x, y, 0f);
    }
}
