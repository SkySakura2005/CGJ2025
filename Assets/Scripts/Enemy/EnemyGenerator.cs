using System;
using System.Collections;
using System.Collections.Generic;
using Enemy.Implement;
using UnityEngine;

public enum Edges{
    Up,Down,Left,Right
}
public class EnemyGenerator : MonoBehaviour
{
    
    private BoxCollider2D _collider;
    private Vector2 _centerPoint;

    public float interval;
    public float currentInterval;
    
    public static List<GameObject> Enemies = new List<GameObject>();
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _centerPoint = _collider.bounds.center;
        currentInterval = interval;
    }

    // Update is called once per frame
    void Update()
    {
        currentInterval-=Time.deltaTime;
        if (currentInterval <= 0)
        {
            Generate();
            currentInterval = interval;
        }
    }

    public void Generate()
    {
        var values = Enum.GetValues(typeof(Edges));
        var random = new System.Random();
        int randomIndex = random.Next(values.Length);
        Edges randomEdge = (Edges)values.GetValue(randomIndex);

        GameObject newEnemy =Instantiate( Resources.Load<GameObject>("Prefab/Enemy"), transform, true);
        switch (randomEdge)
        {
            case Edges.Up:
                newEnemy.transform.position = new Vector3(UnityEngine.Random.Range(_collider.bounds.min.x,_collider.bounds.max.x), _collider.bounds.min.y);
                break;
            case Edges.Down:
                newEnemy.transform.position = new Vector3(UnityEngine.Random.Range(_collider.bounds.min.x,_collider.bounds.max.x), _collider.bounds.max.y);
                break;
            case Edges.Left:
                newEnemy.transform.position = new Vector3(_collider.bounds.min.x,UnityEngine.Random.Range(_collider.bounds.min.y,_collider.bounds.max.y));
                break;
            case Edges.Right:
                newEnemy.transform.position = new Vector3(_collider.bounds.max.x,UnityEngine.Random.Range(_collider.bounds.min.y,_collider.bounds.max.y));
                break;
        }
        newEnemy.GetComponent<Enemy.Enemy>().InitializeEnemy(new SmallEnemy(),_centerPoint);
        Enemies.Add(newEnemy);
    }
}
