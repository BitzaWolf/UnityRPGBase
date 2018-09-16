using UnityEngine;

public class SpawnerTestTool : MonoBehaviour
{
    private const int GROUND_MASK = ~(0x100); // layer number 8

    public float radius = 3;
    public float distance = 10;

    [Range(0, Mathf.PI * 2)]
    public float angle = 0;

    private bool lineOfSightBlocked = false;
    private bool spawnAreaBlocked = false;
    private Vector3 target = new Vector3();
	
	void Update()
    {
        target.x = transform.position.x + Mathf.Cos(angle) * distance;
        target.z = transform.position.z + Mathf.Sin(angle) * distance;
        target.y = transform.position.y;

        Vector3 direction = target - transform.position;
        direction = direction.normalized;
        
        lineOfSightBlocked = Physics.Raycast(transform.position, direction, distance);
        spawnAreaBlocked = Physics.CheckSphere(target, radius, GROUND_MASK);
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = (lineOfSightBlocked) ? Color.red : Color.green;
        Gizmos.DrawLine(transform.position, target);

        Gizmos.color = (spawnAreaBlocked) ? Color.red : Color.green;
        Gizmos.DrawSphere(target, radius);
    }
}
