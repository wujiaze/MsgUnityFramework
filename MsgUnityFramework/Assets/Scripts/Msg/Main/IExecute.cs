namespace Msg
{
    public interface IExecute
    {
        void Execute(int eventCode, object msgValue);
    }
}
