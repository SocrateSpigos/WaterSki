using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathFollower : MonoBehaviour
{

    /*public float speed = 100f;
    public Text distanceMoved;
    float distanceUnit = 0;*/


    const int MAX_FPS = 60;

    public Transform leader;
    public float lagSeconds = 0.5f;

    Vector3[] _positionBuffer;
    float[] _timeBuffer;
    int _oldestIndex;
    int _newestIndex;

    void Start()
    {
        int bufferLength = Mathf.CeilToInt(lagSeconds * MAX_FPS);
        _positionBuffer = new Vector3[bufferLength];
        _timeBuffer = new float[bufferLength];

        _positionBuffer[0] = _positionBuffer[1] = leader.position;
        _timeBuffer[0] = _timeBuffer[1] = Time.time;

        _oldestIndex = 0;
        _newestIndex = 1;

        //InvokeRepeating("distance", 0, 1/speed);
    }

    

    void Update()
    {
        this.transform.LookAt(leader.position);
         // float zDirection = Input.GetAxis("Horizontal");
         // Vector3 moveDirection = new Vector3(0f, 0f, zDirection);



        int newIndex = (_newestIndex + 1) % _positionBuffer.Length;
        if (newIndex != _oldestIndex)
            _newestIndex = newIndex;

        _positionBuffer[_newestIndex] = leader.position;
        _timeBuffer[_newestIndex] = Time.time;

        float targetTime = Time.time - lagSeconds;
        int nextIndex;
        while (_timeBuffer[nextIndex = (_oldestIndex + 1) % _timeBuffer.Length] < targetTime)
            _oldestIndex = nextIndex;

        float span = _timeBuffer[nextIndex] - _timeBuffer[_oldestIndex];
        float progress = 0f;
        if (span > 0f)
        {
            progress = (targetTime - _timeBuffer[_oldestIndex]) / span;
        }

        transform.position = new Vector3(Mathf.Lerp(_positionBuffer[_oldestIndex].x, _positionBuffer[nextIndex].x, progress), transform.position.y, Mathf.Lerp(_positionBuffer[_oldestIndex].z, _positionBuffer[nextIndex].z, progress));

        Move();
        
    }

    void OnDrawGizmos()
    {
        if (_positionBuffer == null || _positionBuffer.Length == 0)
            return;

        Gizmos.color = Color.grey;

        Vector3 oldPosition = _positionBuffer[_oldestIndex];
        int next;
        for (int i = _oldestIndex; i != _newestIndex; i = next)
        {
            next = (i + 1) % _positionBuffer.Length;
            Vector3 newPosition = _positionBuffer[next];
            Gizmos.DrawLine(oldPosition, newPosition);
            oldPosition = newPosition;
        }
    }

    private void Move()
    {

        float zDirection = Input.GetAxis("Horizontal");


        Vector3 moveDirection = new Vector3(0f, 0f, zDirection);
        transform.position += moveDirection;

    }

}