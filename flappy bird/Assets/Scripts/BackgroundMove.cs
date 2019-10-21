using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float speedMove;
    public float rangeMove;

    private bool isPlay;
    private Vector3 objectPosition;

    void Start()
    {
        isPlay = false;
        objectPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) isPlay = true;
        if (isPlay)
        {
            Vector3 vectorMove = new Vector3(speedMove * Time.deltaTime, transform.position.y, 0);
            transform.Translate(vectorMove);
            if (Vector3.Distance(objectPosition, transform.position) > rangeMove)
                transform.position = objectPosition;
        }
        
    }
}
