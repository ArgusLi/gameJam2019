using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public int numObstacles;
    public Sprite sprite1;
    public Sprite sprite2;

    private GameObject[] obstacles;
    static private Rigidbody2D[] bodies;
    private PolygonCollider2D[] colliders;

    static List<int> waitingList;

    private static Vector2 stop = new Vector2(0, 0);
    private static Vector2 up = new Vector2(0, 5);
    private static Vector2 down = new Vector2(0, -5);
    private static Vector2 left = new Vector2(-5, 0);
    private static Vector2 right = new Vector2(5, 0);

    public static void PlaceObstacle(float x, float y){
        if(waitingList.Count == 0){
            return;
        }
        Rigidbody2D body = bodies[waitingList[0]];
        waitingList.RemoveAt(0);
        body.velocity = down;
        body.MovePosition(new Vector2(x, y));
    }

    void ResetPosition(int i) {
        bodies[i].MovePosition(new Vector2(-1000, -1000));
        bodies[i].velocity = stop;
        waitingList.Add(i);
    }

    void Start() {
        waitingList = new List<int>();
        obstacles = new GameObject[numObstacles];
        bodies = new Rigidbody2D[numObstacles];
        colliders = new PolygonCollider2D[numObstacles];
        
        for (int i = 0; i < numObstacles; i++) {
            obstacles[i] = new GameObject("Obstacle" + i.ToString());
            
            bodies[i] = obstacles[i].AddComponent<Rigidbody2D>();   
            bodies[i].freezeRotation = true;
            bodies[i].isKinematic = true;
            
            colliders[i] = obstacles[i].AddComponent<PolygonCollider2D>();
            
            SpriteRenderer renderer = obstacles[i].AddComponent<SpriteRenderer>();
            if (i % 2 == 0) {
                renderer.sprite = sprite1;
            } else {
                renderer.sprite = sprite2;
            }
            obstacles[i].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            
            ResetPosition(i);
        }   
    }

    
}
