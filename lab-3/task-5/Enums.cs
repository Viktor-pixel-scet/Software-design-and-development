namespace task_5
{
    public enum DisplayType
    {
        Block,
        Inline
    }

    public enum ClosingType
    {
        Normal,      // Тег із закриваючим тегом (<div></div>)
        SelfClosing  // А тут тег, що закривається сам (<img />)
    }
}
