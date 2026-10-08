using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    [SerializeField] private float gravityStrength = 10f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<GreenProjectile>() || collision.GetComponent<YellowProjectile>())
            collision.attachedRigidbody.AddForce(-(transform.position - collision.transform.position).normalized * gravityStrength);
        else
            collision.attachedRigidbody.AddForce((transform.position - collision.transform.position).normalized * gravityStrength);
    }
}
