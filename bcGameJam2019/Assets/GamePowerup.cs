using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePowerup : MonoBehaviour
{
    public Sprite swapSprite;
    public Sprite sync2Sprite;
    public Sprite sync4Sprite;
    public Sprite slowSprite;
    public Sprite boostSprite;
    public Sprite spinSprite;
    public GameObject ship;
    public int numPowerups;
    
    private System.Random rand;
    private GameObject[] powerups;
    private Rigidbody2D[] rbs;
    private Vector2[] positions;
    private PolygonCollider2D[] colliders;
    private Sprite[] sprites;
    
    void ResetPosition(int i) {
        positions[i].x = ship.transform.position.x + rand.Next(5) - 2;
        positions[i].y = ship.transform.position.y + 5 + rand.Next(10);
        rbs[i].MovePosition(positions[i]);
    }
 
    void Start() {
        rand = new System.Random();
        powerups = new GameObject[numPowerups];
        rbs = new Rigidbody2D[numPowerups];
        positions = new Vector2[numPowerups];
        colliders = new PolygonCollider2D[numPowerups];
        sprites = new Sprite[] {swapSprite, sync2Sprite, sync4Sprite, slowSprite, boostSprite, spinSprite};
        for (int i = 0; i < numPowerups; i++) {
           GameObject powerup = new GameObject("Powerup" + i.ToString());
           SpriteRenderer renderer = powerup.AddComponent<SpriteRenderer>();
           powerup.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
           renderer.sprite = sprites[i];
           Rigidbody2D rb = powerup.AddComponent<Rigidbody2D>();
           rb.freezeRotation = true;
           powerup.AddComponent<PolygonCollider2D>();
           
           powerups[i] = powerup;
           rbs[i] = rb;
           positions[i] = Vector2.zero;
           ResetPosition(i);
        }
    }

    void Update()
    {
        for (int i = 0; i < numPowerups; i++) {
            rbs[i].velocity = new Vector2(0, 3);
            if (rbs[i].position.y < ship.transform.position.y - 10 + rand.Next(5)) {
                ResetPosition(i);
            } else if (rbs[i].position.y > ship.transform.position.y + 50) {
                ResetPosition(i);
            }
        }
    }
}
