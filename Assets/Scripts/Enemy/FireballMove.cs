using UnityEngine;

public class FireballMove : MonoBehaviour
{
    public float fireballSpeed;
    public Vector2 dir;
    void Start()
    {   
        if (dir==Vector2.up) transform.rotation = Quaternion.Euler(0, 0, 90);
        else if (dir==Vector2.left) transform.rotation = Quaternion.Euler(0, 0, 180);
        else if (dir==Vector2.down) transform.rotation = Quaternion.Euler(0, 0, 270);
    }

    void FixedUpdate()
    {
        transform.position += fireballSpeed * Time.deltaTime * (Vector3)dir;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(!other.gameObject.CompareTag("Enemy")) Destroy(this.gameObject);
        
    }
    
}