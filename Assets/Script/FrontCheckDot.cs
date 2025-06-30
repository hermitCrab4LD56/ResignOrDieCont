using UnityEngine;

public class FrontCheckDot : MonoBehaviour
{
    public GameObject target;
    

    void Update()
    {
        Vector2 toTarget = (target.transform.position - transform.position).normalized;
        Vector2 facingDirection = transform.right; // or transform.up for vertical facing

        float dot = Vector2.Dot(facingDirection, toTarget);

        if (dot > 0.9f) // closer to 1 means more directly in front
        {
            Debug.Log("Target is roughly in front!");
            
        }
    }
}
