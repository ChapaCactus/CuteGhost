namespace CCG
{
    /// <summary>
    /// プレイヤー目視対象になる要素に継承させるInterface
    /// </summary>
    public interface IInsightable
    {
        void Action();

        void OnInsightEnter();
        void OnInsightExit();
    }
}