using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public int numPowerups;
    public Sprite boostSprite;
    public Sprite slowSprite;
    public Sprite spinSprite;
    public Sprite swapSprite;
    public Sprite sync2Sprite;
    public Sprite sync4Sprite;    

    private GameObject[] powerups;
    private Rigidbody2D[] bodies;
    private PolygonCollider2D[] colliders;

    void ResetPosition(int i) {
        bodies[i].MovePosition(new Vector2(-1000, -1000));
    }

    void Start() {
        powerups = new GameObject[numPowerups];
        bodies = new Rigidbody2D[numPowerups];
        colliders = new PolygonCollider2D[numPowerups];
        
        for (int i = 0; i < numPowerups; i++) {
            powerups[i] = new GameObject("Powerup" + i.ToString());
            
            bodies[i] = powerups[i].AddComponent<Rigidbody2D>();   
            bodies[i].freezeRotation = true;
            bodies[i].isKinematic = true;
            
            colliders[i] = powerups[i].AddComponent<PolygonCollider2D>();
            
            SpriteRenderer renderer = powerups[i].AddComponent<SpriteRenderer>();
            switch (i % 6) {
            case 0:
                renderer.sprite = boostSprite;
                break;
            case 1:
                renderer.sprite = slowSprite;
                break;
            case 2:
                renderer.sprite = spinSprite;
                break;
            case 3:
                renderer.sprite = swapSprite;
                break;
            case 4:
                renderer.sprite = sync2Sprite;
                break;
            case 5:
                renderer.sprite = sync4Sprite;
                break;
            }
            powerups[i].transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            
            ResetPosition(i);
        }   
    }
}
