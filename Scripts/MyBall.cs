using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBall : MonoBehaviour
{
   
    //글로벌 변수 (퍼블릭)를 만들면 유니티 스크립트에서 수치 전환 가능.
    public float jumpPower;
    bool isJump;
    public int itemCount;
    AudioSource audio;
    public GameManagerLogic manager;

    //컴포넌트 가져오기
    Rigidbody rigid;


    // Start is called before the first frame update
    void Awake()
    {
        //초기화
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

        //AddForce(Vec) 벡터의 방향과 크기로 힘을 줌
        //ForceMode 가속과 무게를 반영 해 힘을 주는 방식이며 힘방향으로 계속 속도가 증가, impulse는 무게에 영향을 받는다
        //rigid.AddForce(Vector3.up*5, ForceMode.Impulse);
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump") && false == isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }
    //트리거
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if (other.tag == "Point")
        {
            if (itemCount == manager.TotalItemCount)
            {
                if(manager.Stage == 2)
                {
                    SceneManager.LoadScene(0);
                }
                else
                {
                    //game clear
                    SceneManager.LoadScene(manager.Stage + 1);
                }
            }
            else
            {
                //restart
                SceneManager.LoadScene(manager.Stage);
            }
        }
        else if (other.gameObject.tag == "BoxCollider")
        {
            SceneManager.LoadScene(manager.Stage);
        }
    }
}