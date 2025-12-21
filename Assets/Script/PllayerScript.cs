using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed=5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 物理演算をしたい場合はFixedUpdateを使うのが一般的
    void FixedUpdate()
    {
        

        //右入力で左向きに動く
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed*speed);
        }
        //左入力で左向きに動く
        else if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -speed*speed);
        }
        //上入力で上向きに動く
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * speed);
        }
        //下入力で下向きに動く
        else if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce(transform.up * -speed);
        }
        //ボタンを話すと止まる
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

    }
}
