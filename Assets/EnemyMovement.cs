using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;           // Speed of the enemy
    public Transform pointA;           // Starting point of patrol
    public Transform pointB;           // Ending point of patrol

    private Transform currentTarget;   // The current target point (A or B)

    void Start()
    {
        // Start by moving towards point B
        currentTarget = pointB;
    }

    void Update()
    {
        // Move towards the current target (either pointA or pointB)
        MoveTowardsTarget();

        // Check the 2D distance only (ignoring Z-axis)
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), 
                             new Vector2(currentTarget.position.x, currentTarget.position.y)) < 0.05f)
        {
            Debug.Log("Reached " + currentTarget.name);
            SwitchTarget();
        }
    }

    void MoveTowardsTarget()
    {
        // Move the enemy towards the current target
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);
    }

    void SwitchTarget()
    {
        // Flip the enemy and switch the target to the other point
        Flip();

        // Switch between pointA and pointB
        if (currentTarget == pointB)
        {
            currentTarget = pointA;
        }
        else
        {
            currentTarget = pointB;
        }

        // Log target switch for debugging
        Debug.Log("Switching to " + currentTarget.name);
    }

    void Flip()
    {
        // Flip the enemy's sprite on the x-axis
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
