using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Leopotam.EcsProto.Unity;
using UnityEngine;

sealed class ECSStartup : MonoBehaviour
{
    [SerializeField] private EcsGate _ecsGate;

    private ProtoWorld _world;
    private IProtoSystems _systems;

    private Controls _controls;
    private GlobalData _global;


    private void Awake()
    {
        _global = new GlobalData();
        _controls = new Controls();

        _global.Controls = _controls;
    }

    void Start()
    {

        MainAspect asp = new MainAspect();
        
        _world = new ProtoWorld( asp);
        _systems = new ProtoSystems(_world);
        
        _ecsGate.SetWorld(asp, _global);
        _global.EcsGate = _ecsGate;
        
        _systems
            // Инъекция в поля систем.
            .AddModule(new AutoInjectModule())
            // Модуль отладочной интеграции в unity.
            .AddModule(new UnityModule())

            // Регистрация дополнительных модулей.
            // .AddModule (new TestModule1 ())

            // Регистрация систем.
            //.AddSystem(new InitAllSystem())
            .AddSystem(new InputControlSystem())
            .AddSystem(new InitAllSystem())
            
            
            
            
            .AddSystem(new CheckFallSystem())
            .AddSystem(new FallSystem())
            .AddSystem(new FallStopSystem())
            .AddSystem(new FallEndSystem())
            
            
            
            .AddSystem(new CheckGlideSystem())
            .AddSystem(new IsGlideSystem())
            
            
            //.AddSystem(new MoveSystem())
            //.AddSystem(new RemoveGrassSystem())
            
                       
            
            
            .AddSystem(new SoundFxSystem())
            .DelHere<InputControl>()
            // .AddSystem (new TestSystem2 ())

            // Регистрация сервисов. ( DI )
            .AddService(_global)
            .Init();
    }

    void Update() => _systems?.Run();


    void OnDestroy()
    {
        // Очистка систем.
        _systems?.Destroy();
        _systems = null;

        // Очистка дополнительных миров.

        // Очистка основного мира.
        _world?.Destroy();
        _world = null;
    }

    private void OnEnable() => _controls.Enable();

    private void OnDisable() => _controls.Disable();
}


public class MainAspect : ProtoAspectInject
{
    public readonly ProtoPool<SoundFx> SoundFx;  
    public readonly ProtoPool<InputControl> InputControl;
    
    public readonly ProtoPool<Position> Position;
    
    public readonly ProtoPool<CanFall> CanFall;
    public readonly ProtoPool<CanGlide> CanGlide;
    
    public readonly ProtoPool<IsFall>  IsFall;
    public readonly ProtoPool<IsGlide>  IsGlide;
    
    public readonly ProtoPool<FallEnd>  FallEnd;
    

}