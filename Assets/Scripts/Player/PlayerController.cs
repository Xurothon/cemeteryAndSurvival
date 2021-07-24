using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 _movement;
    private Animator _animator;
    Rigidbody _rigidbody;
    private Vector3 currentLookTarget;

    private void Move(float h, float v)
    {
        _movement.Set(h, 0f, v);
        _movement = _movement.normalized * speed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + _movement);
    }

    private void Turning()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.point != currentLookTarget)
            {
                currentLookTarget = hit.point;
            }
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10.0f);
        }
    }

    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        _animator.SetBool("IsWalking", walking);
        _animator.SetBool("IsShooting", false);
    }

    private void AnimatingShoot()
    {
        _animator.SetBool("IsShooting", true);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
        if (Input.GetButton("Fire1"))
        {
            AnimatingShoot();
        }
    }
}