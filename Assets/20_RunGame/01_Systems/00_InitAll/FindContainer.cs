using UnityEngine;

sealed partial class InitAllSystem
{
    private void FindContainer()
    {
        _global.SoundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        
        _global.GroundContainer = GameObject.Find("GroundContainer");
        _global.StoneBlockContainer = GameObject.Find("StoneBlockContainer");
        _global.CharacterContainer = GameObject.Find("CharacterContainer");
        
        
        
    }
}