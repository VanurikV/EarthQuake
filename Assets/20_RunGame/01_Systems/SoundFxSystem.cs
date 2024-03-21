using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


sealed class SoundFxSystem : IProtoRunSystem
{
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;
    
    [DI] ProtoIt _filter = new (It.Inc<SoundFx> ());
        
    

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var sfx = ref _aspect.SoundFx.Get(i);
            _global.SoundManager.PlaySfx(sfx.SfxClip);
        }
    }
}