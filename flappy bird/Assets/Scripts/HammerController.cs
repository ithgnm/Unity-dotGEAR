using UnityEngine;

public class HammerController : MonoBehaviour
{
    public float hammerSpeed;

    private float direction;

    void Start()
    {
        direction = 1;
    }

    void Update()
    {
        if (transform.rotation.z > 0.36f)
        {
            direction = -1;
            hammerSpeed = direction * hammerSpeed;
        }
        if (transform.rotation.z < -0.36f)
        {
            direction = -1;
            hammerSpeed = direction * hammerSpeed;
        }
        transform.Rotate(0, 0, hammerSpeed);
    }
}
