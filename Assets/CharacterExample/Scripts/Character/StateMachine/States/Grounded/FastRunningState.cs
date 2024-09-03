using UnityEngine.InputSystem;

public class FastRunningState : RunningState
{
    private FastRunningStateConfig _config;
    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.FastRunningStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        Data.Speed = _config.Speed;
        Input.Movement.FastRun.canceled += OnFastRunKeyUp;
    }

    private void OnFastRunKeyUp(InputAction.CallbackContext context)
    {
        StateSwitcher.SwitchState<RunningState>();
    }

    public override void Exit()
    {
        base.Exit();

        Input.Movement.FastRun.canceled -= OnFastRunKeyUp;
    }

    public override void Update()
    {
        base.Update();
    }
}
