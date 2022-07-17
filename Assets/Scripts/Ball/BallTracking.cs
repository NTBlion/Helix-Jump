using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _cameraPisition;
    private Vector3 _minimumBallPosition;


    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _cameraPisition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;

        TrackBall();
    }

    private void Update()
    {
        if (_ball.transform.position.y < _minimumBallPosition.y)
        {
            TrackBall();
            _minimumBallPosition.y = _ball.transform.position.y;
        }
    }

    private void TrackBall()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPisition = _ball.transform.position;
        Vector3 diricetion = (beamPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPisition -= diricetion * _lenght;
        transform.position = _cameraPisition;
        transform.LookAt(_ball.transform);
    }
}
