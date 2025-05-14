using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingToPoint : MonoBehaviour
{
    public float speed = 1f;
    public int pointIndex;
    public float pointDistance = Mathf.Infinity;
    public Transform pointsHolder;
    public List<Transform> points = new List<Transform>();


    private void Start()
    {
        this.LoadPoints();
    }
    private void Update()
    {
        this.PointMoving();
        NextPointCalculate();
    }
    protected virtual void LoadPoints()
    {
        string name = transform.name + "_Points";
        this.pointsHolder = GameObject.Find(name).transform;
        foreach (Transform point in this.pointsHolder)
        {
            this.points.Add(point);
        }
    }

    protected virtual void PointMoving()
    {
        float step = this.speed * Time.deltaTime;
        Transform currentPoint = this.CurrentPoint();
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, step);
    }

    protected virtual void NextPointCalculate()
    {
        this.pointDistance = Vector3.Distance(transform.position, this.CurrentPoint().position);
        if (this.pointDistance == 0f)
        {
            this.pointIndex++;
            if (this.pointIndex >= this.points.Count)
            {
                this.pointIndex = 0;
            }
        }
    }


    public virtual Transform CurrentPoint()
    {
        return this.points[this.pointIndex];
    }
}
