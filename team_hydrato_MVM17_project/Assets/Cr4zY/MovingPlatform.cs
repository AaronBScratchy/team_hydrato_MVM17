using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool forth;
    float progress;
    float desiredTime = 3;
    private float speed = 7;

    private Rigidbody2D rb;

    [SerializeField] private Vector2 pointA;
    [SerializeField] private Vector2 pointB;

    private void Awake()
    {
        forth = true;
        progress = 0;   
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MovePlatform());
    }

    private IEnumerator MovePlatform()
    {
        bool reached = false;
        while (!reached)
        {

        }


        forth = !forth;

        StartCoroutine(MovePlatform());
    }

}
