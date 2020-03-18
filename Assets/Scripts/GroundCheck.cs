using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("エフェクトがついた床を判定するか")] public bool checkPlatformGround = true;


    private string groundTag = "Ground";
    private string platformTag = "GroundPlatform";
    private string moveFloorTag = "MoveFloor";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay,isGroundExit;

    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if(isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundEnter = true;
           //Debug.Log("何かが判定に入りました");
        }
        else if(checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag))
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundStay = true;
            //Debug.Log("何かが判定に入り続けています");
        }
        else if (checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag))
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag)
        {
            isGroundExit = true;
            //Debug.Log("何かが判定から出ました");
        }
        else if (checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag))
        {
            isGroundExit = true;
        }
    }


}
