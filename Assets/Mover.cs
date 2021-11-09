using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Tooltip("Frog speed in m/s")]
    [SerializeField] float speed = 1f;
    Bounds backgroundBounds;

    private void Start()
    {
        backgroundBounds = GameObject.FindGameObjectWithTag("Background").GetComponent<SpriteRenderer>().bounds;
    }
    void Update()
    {
        // Check input's direction
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 newPosition = transform.position +
                                new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;

        // Check that user stay within background bounds.
        if (backgroundBounds.Contains(newPosition))
        {
            transform.position = newPosition;
        }
    }
}
