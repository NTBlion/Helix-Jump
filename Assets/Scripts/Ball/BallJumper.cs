using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    private bool _isCoroutineEnable = true;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlatformSigment platformSigment))
        {
            if (_isCoroutineEnable == true)
            {
                StartCoroutine(DelayBeforeJump());
            }
        }
    }
    private IEnumerator DelayBeforeJump()
    {
        _isCoroutineEnable = false;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        yield return null;
        _isCoroutineEnable = true;
    }
}
