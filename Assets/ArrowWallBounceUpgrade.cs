using UnityEngine;

public class ArrowWallBounceUpgrade : UpgradeBase
{
    public override void AddUpgrade()
    {
        PlayerMovement.playerInstance.GetComponent<ManualShoot>().bulletType.gameObject.GetComponent<Bullet>().bounce = true;
    }
}