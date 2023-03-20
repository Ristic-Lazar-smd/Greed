using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaWalls : MonoBehaviour
{
    public static ArenaWalls arenaWallsInstance;
    public Collider2D[] allColliders;
    
    void Awake()=> arenaWallsInstance = this;
    void Start()
    {
        allColliders = gameObject.GetComponentsInChildren<Collider2D>(true);
    }
}
