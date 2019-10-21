using UnityEngine;

public class SteelController : MonoBehaviour
{
    public float steelMove;
    public float steelJump;
    public bool isBackground;
    public float removePosition;

    public float maxPosition;
    public float minPosition;
    private bool isPlay;

    void Start()
    {
        float x = Random.Range(minPosition, maxPosition);
        transform.localPosition = new Vector3(x, transform.position.y, 0);
    }

    void Update()
    {   
        if (Input.GetMouseButtonDown(0)) isPlay = true;
        if (transform.localPosition.y < removePosition)
        {
            if (isBackground) Destroy(gameObject);
            SteelMove();
        }
        if (isPlay) transform.Translate(Vector3.down * steelMove * Time.deltaTime);
    }

    private void SteelMove()
    {
        float x = Random.Range(minPosition, maxPosition);
        transform.localPosition = new Vector3(x, steelJump, 0);
    }
}
