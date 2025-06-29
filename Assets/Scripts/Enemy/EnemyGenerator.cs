using System;
using System.Collections;
using System.Collections.Generic;
using Enemy.Implement;
using Enemy.Interface;
using UnityEngine;

public enum Edges{
    Up,Down,Left,Right
}
public class EnemyGenerator : MonoBehaviour
{
    
    private BoxCollider2D _collider;
    private Vector2 _centerPoint;

    public float startTime;
    
    private float greenInterval=3;
    
    private float fireInterval=5;
    
    private float rockInterval=7;
    
    public static List<GameObject> Enemies = new List<GameObject>();
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _centerPoint = _collider.bounds.center;

        greenInterval = 3;
        fireInterval = 5;
        rockInterval = 7;
        startTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        greenInterval-= Time.deltaTime;
        fireInterval-= Time.deltaTime;
        rockInterval-= Time.deltaTime;
        if (greenInterval <= 0)
        {
            Generate(new GreenSmile());
            greenInterval=3-startTime/60;
            if(greenInterval<1) greenInterval=1;
        }

        if (startTime >= 60 && fireInterval <= 0)
        {
            Generate(new FireSmile());
            fireInterval=5-startTime/90;
            if(fireInterval<2) fireInterval=2;
        }

        if (startTime >= 120 && rockInterval <= 0)
        {
            Generate(new RockSmile());
            rockInterval=7-startTime/120;
        }
    }
    
    private void Generate(IEnemyType enemyType)
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
        newEnemy.GetComponent<Enemy.Enemy>().InitializeEnemy(enemyType,_centerPoint);
        Enemies.Add(newEnemy);
    }
}
