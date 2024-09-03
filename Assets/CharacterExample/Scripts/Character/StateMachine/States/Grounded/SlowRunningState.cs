using UnityEngine.InputSystem;

public class SlowRunningState : RunningState
{
    private SlowRunningStateConfig _config;
    public SlowRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.SlowRunningStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
        Input.Movement.SlowRun.canceled += OnSlowRunKeyUp;
    }


    public override void Exit()
    { 
        base.Exit(); 

        Input.Movement.SlowRun.started -= OnSlowRunKeyUp;
    }

    public override void Update()
    {
        base.Update();
    }
    private void OnSlowRunKeyUp(InputAction.CallbackContext context)
    {
        StateSwitcher.SwitchState<RunningState>();
    }

}
