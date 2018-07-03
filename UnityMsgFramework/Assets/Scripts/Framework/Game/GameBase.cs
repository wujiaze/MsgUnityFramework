

public class GameBase : MonoBase {

    /// <summary>
    /// 绑定事件码
    /// </summary>
    /// <param name="eventCodes">事件码</param>
    protected override void BindEvent(params int[] eventCodes)
    {
        base.BindEvent(eventCodes);
        GameMgr.Instance.Add(eventCodes, this);
    }
    /// <summary>
    /// 解绑事件码
    /// </summary>
    protected override void UnBindEvent()
    {
        UnBind(GameMgr.Instance, this);
    }


}
