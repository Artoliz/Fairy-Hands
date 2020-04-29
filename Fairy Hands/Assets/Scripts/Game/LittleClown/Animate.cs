using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Animate : MonoBehaviour
{
    private Animation _animation = null;
    private bool _isWalking = true;

    public Transform _StartPos;
    public Transform _EndPos;

    private Vector3 _destination;

    private enum ToDestination
    {
        Start,
        End
    };

    private ToDestination _destinationState;

    void Awake()
    {
        _animation = GetComponent<Animation>();
        _destination = _EndPos.position;
        _destinationState = ToDestination.End;
    }

    void Update()
    {
        if (_isWalking)
        {
            _animation.Play("T_ACT_DOTA_RUN");
            transform.position = Vector3.MoveTowards(transform.position, _destination, Time.deltaTime);
            transform.LookAt(new Vector3(_destination.x, transform.position.y, _destination.z));

            if (Vector3.Distance(transform.position, _destination) < 0.001f)
            {
                if (_destinationState == ToDestination.End)
                {
                    _destination = _StartPos.position;
                    _destinationState = ToDestination.Start;
                }
                else
                {
                    _destination = _EndPos.position;
                    _destinationState = ToDestination.End;
                }
                _isWalking = false;
            }
        } else
        {
            _animation.Play("T_ACT_DOTA_IDLE");
            transform.LookAt(new Vector3(Player.instance.gameObject.transform.position.x, transform.position.y, Player.instance.gameObject.transform.position.z));
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        _isWalking = true;
    }

    public void SetIsWalking(bool walk)
    {
        _isWalking = walk;
    }
}
