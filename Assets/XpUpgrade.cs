using UnityEngine;

public class XpUpgrade : UpgradeBase
{
    public override void AddUpgrade()
    {
        PlayerMovement.playerInstance.GetComponent<PlayerExp>().xpMultiplier += 2;
    }
}

