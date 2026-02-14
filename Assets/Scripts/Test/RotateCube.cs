using UnityEngine;

public class RotateCube : MonoBehaviour
{
    private Vector2 touchStart;
    private Vector3 rotation;
    public float rotationSpeed = 0.2f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 delta = touch.deltaPosition;
                rotation.y -= delta.x * rotationSpeed;
                rotation.x += delta.y * rotationSpeed;

                transform.rotation = Quaternion.Euler(rotation);
            }
        }
    }
}
