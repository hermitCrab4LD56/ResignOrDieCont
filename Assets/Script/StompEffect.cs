using UnityEngine;

public class StompEffect : MonoBehaviour
{
    public float floatUpSpeed = 2f;
    public float lifeTime = 1f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += Vector3.up * floatUpSpeed * Time.deltaTime;
    }
}
