using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform camTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(45, camTransform.rotation.y, camTransform.rotation.z);
    }
}
