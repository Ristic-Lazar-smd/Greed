using UnityEngine;

public class ExtraArrowUpgrade : UpgradeBase
{
    public override void AddUpgrade()
    {
        PlayerMovement.playerInstance.GetComponent<ManualShoot>().extraShot = true;
        PlayerMovement.playerInstance.GetComponent<ManualShoot>().numberOfShots++;
    }
}
