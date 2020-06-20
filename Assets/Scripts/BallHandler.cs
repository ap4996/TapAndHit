using UnityEngine;

public class BallHandler : MonoBehaviour
{
    private float ballTimer;
    public float endTimer;

    private void Awake()
    {
        ballTimer = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag.ToLower().Contains("enemy"))
        {
            //DestroyBall();
        }
    }

    private void DestroyBall()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        ballTimer += Time.deltaTime;
        if(ballTimer >= endTimer)
        {
            DestroyBall();
        }
    }
}
