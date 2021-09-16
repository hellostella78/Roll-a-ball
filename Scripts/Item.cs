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
        //rotate the item with the center of y axis. 로컬 좌표계가 아닌 월드 좌표계로 회전하게 만듦.
        transform.Rotate(Vector3.up* rotateSpeed* Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        /*//플레이어가 아이템을 먹으면
        if(other.name == "Player")
        {
            MyBall player = other.GetComponent<MyBall>();
            //플레이어 점수를 올린다
           // player.itemCount++;
             
        }*/
    }
}
