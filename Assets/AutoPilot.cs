using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPilot : MonoBehaviour
{
    [SerializeField] float speed = 1f;

    [Tooltip("Write '-1' for LEFT or '1' for RIGHT in the direction field.")]
    [SerializeField] int direction = 1;

    void Update()
    {
        // Move according to direction 'speed'
        // deltaTime turns it into m/s
        if (direction == -1 || direction == 1)
        {
            transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
        }
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }
    public void setDirection(int direction)
    {
        this.direction = direction;
    }
    public float getSpeed()
    {
        return speed;
    }
    public int getDirection()
    {
        return direction;
    }
}
