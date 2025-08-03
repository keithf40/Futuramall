using UnityEngine;

public class FishSwim : MonoBehaviour
{
    public float speed = 2f;
    public float swimRange = 5f;
    public float minY = 4f;
    public float maxY = 5f;

    private Vector3 targetPosition;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            PickNewTarget();
        }
    }

    void PickNewTarget()
    {
        float x = transform.position.x + Random.Range(-swimRange, swimRange);
        float y = Random.Range(minY, maxY);
        float z = transform.position.z + Random.Range(-swimRange, swimRange);

        targetPosition = new Vector3(x, y, z);
    }
}
