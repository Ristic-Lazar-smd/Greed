using UnityEngine;

public class AttackStep : MonoBehaviour
{
    Vector3 stepDirection;
    public float stepSpeed;
    Transform playerTransform;


    void Awake()
    {
        playerTransform = transform.parent.transform;
    }

    public void Step(){
        //playerTransform = PlayerMovement.playerInstance.transform;
        stepDirection = playerTransform.InverseTransformPoint(transform.GetChild(0).position);
        playerTransform.position += stepDirection * 2 * stepSpeed * Time.deltaTime;
    }
}
