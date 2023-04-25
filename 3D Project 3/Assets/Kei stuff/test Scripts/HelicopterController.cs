using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [SerializeField] private float _responsiveness = 1000f;
    [SerializeField] private float _throttleAmt = 40f;
    private float _throttle;

    private float _roll;
    private float _pitch;
    private float _yaw;

    [SerializeField] private float _rotorSpeedModifier = 10f;
    [SerializeField] private Transform _rotorTransform;

    private bool _frozen = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInputs();

        _rotorTransform.Rotate(Vector3.up * _throttle * _rotorSpeedModifier);
    }

    private void FixedUpdate()
    {
        if (_throttle > 0f)
        {
            Unfreeze();
            _rigidbody.AddForce(transform.up * _throttle, ForceMode.Impulse);
        }
        else
        {
            Freeze();
        }

        _rigidbody.AddTorque(transform.right * _pitch * _responsiveness);
        _rigidbody.AddTorque(transform.forward * _roll * _responsiveness);
        _rigidbody.AddTorque(transform.up * _yaw * _responsiveness);
    }

    private void HandleInputs()
    {
        _roll = Input.GetAxis("Roll");
        _pitch = Input.GetAxis("Pitch");
        _yaw = Input.GetAxis("Yaw");
        if (Input.GetKey(KeyCode.Space))
        {
            _throttle += Time.deltaTime * _throttleAmt;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            _throttle -= Time.deltaTime * _throttleAmt;
        }
        else
        {
            _throttle = Mathf.Lerp(_throttle, 0f, Time.deltaTime * 10f);
        }

        _throttle = Mathf.Clamp(_throttle, -100f, 100f);
    }

    private void Freeze()
    {
        if (!_frozen)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePositionX |
                                      RigidbodyConstraints.FreezePositionY |
                                      RigidbodyConstraints.FreezePositionZ;

            _frozen = true;
            Debug.Log("Frozen");
        }
    }

    private void Unfreeze()
    {
        if (_frozen)
        {
            _rigidbody.constraints = RigidbodyConstraints.None;

            _frozen = false;
            Debug.Log("Unfrozen");
        }
    }
}