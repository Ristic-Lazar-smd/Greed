using UnityEngine;

public class AttackStep : MonoBehaviour
{
    [SerializeField] public MeleeMain meleeMain;
    Vector3 stepDirection;
    public float stepSpeed;

    public void Step(){
        stepDirection = transform.InverseTransformPoint(meleeMain.transform.GetChild(0).position);
        transform.position +=  stepDirection * 2 * stepSpeed * Time.deltaTime;
        Debug.Log(stepDirection);
    }
}
