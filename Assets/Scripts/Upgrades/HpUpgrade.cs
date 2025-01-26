using UnityEngine;

public class HpUpgrade : UpgradeBase
{
    public override void AddUpgrade()
    {
        PlayerMovement.playerInstance.GetComponent<DamageableCharacter>().maxHp += 5;
        PlayerMovement.playerInstance.GetComponent<DamageableCharacter>().Health = +5;
    }
}
