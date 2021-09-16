using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float rotateSpeed;
    

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the item with the center of y axis. ���� ��ǥ�谡 �ƴ� ���� ��ǥ��� ȸ���ϰ� ����.
        transform.Rotate(Vector3.up* rotateSpeed* Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        /*//�÷��̾ �������� ������
        if(other.name == "Player")
        {
            MyBall player = other.GetComponent<MyBall>();
            //�÷��̾� ������ �ø���
           // player.itemCount++;
             
        }*/
    }
}
