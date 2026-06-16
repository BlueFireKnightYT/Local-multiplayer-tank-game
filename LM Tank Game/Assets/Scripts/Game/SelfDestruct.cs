using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float destroyTimer;
    void Start()
    {
        Destroy(this.gameObject, destroyTimer);
    }
}
