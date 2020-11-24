using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Vector3 max, min;
    private const float clearRadius = 2f;

    public float Distance(Vector3 pos)
    {
        return (transform.position - pos).magnitude;
    }

    public Vector3 Direction(Vector3 pos)
    {
        return (transform.position - pos).normalized;
    }

    public void Randomize()
    {
        float xR = Random.Range(min.x, max.x);
        float xY = Random.Range(min.y, max.y);
        float xZ = Random.Range(min.z, max.z);
        transform.localPosition = new Vector3(xR, xY, xZ);
        if (Physics.OverlapSphere(transform.position, clearRadius, Obstacle.LayerMask).Length > 0)
        {
            Randomize();
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.layer == Obstacle.Layer)
        {
            Randomize();
        }
    }
}