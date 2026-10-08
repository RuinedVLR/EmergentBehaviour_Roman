using UnityEngine;

public class BlueProjectile : MonoBehaviour
{
    [SerializeField] float lifespan = 20f;

    private void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<BlueProjectile>() != null)
        {
            collision.attachedRigidbody.AddForce((transform.position - collision.transform.position).normalized * 5f);
        }
    }
}
