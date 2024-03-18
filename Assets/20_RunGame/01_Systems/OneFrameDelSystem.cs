using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;

sealed class OneFrameDelSystem : IProtoRunSystem
    {
        [DI] GlobalData _global;
        [DI] private MainAspect _aspect;
        
        [DI] ProtoIt _filter = new (It.Inc<OneFrameComponent> ());
        
        
       
        
        public void Run()
        {
            foreach (var ent in _filter)
            {
               _aspect.World().DelEntity(ent);
            }
        }


      
    }
