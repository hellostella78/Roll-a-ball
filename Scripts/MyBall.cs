using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyBall : MonoBehaviour
{
   
    //�۷ι� ���� (�ۺ�)�� ����� ����Ƽ ��ũ��Ʈ���� ��ġ ��ȯ ����.
    public float jumpPower;
    bool isJump;
    public int itemCount;
    AudioSource audio;
    public GameManagerLogic manager;

    //������Ʈ ��������
    Rigidbody rigid;


    // Start is called before the first frame update
    void Awake()
    {
        //�ʱ�ȭ
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

        //AddForce(Vec) ������ ����� ũ��� ���� ��
        //ForceMode ���Ӱ� ���Ը� �ݿ� �� ���� �ִ� ����̸� ���������� ��� �ӵ��� ����, impulse�� ���Կ� ������ �޴´�
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
    //Ʈ����
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