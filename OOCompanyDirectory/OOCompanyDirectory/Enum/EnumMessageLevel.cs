namespace OOCompanyDirectory
{
    /// <summary>
    /// メッセージレベル
    /// </summary>
    public enum MessageLevel
    {
        /// <summary>確認</summary>
        Information,

        /// <summary>警告</summary>
        Warning,

        /// <summary>エラー</summary>
        Error,
    }

    /// <summary>
    /// メッセージレベル・拡張
    /// </summary>
    public static class MessageLevelExt
    {
        /// <summary>
        /// メッセージレベル・拡張メソッド
        /// </summary>
        /// <param name="messageLevel">メッセージレベル</param>
        /// <returns>メッセージレベル名称</returns>
        public static string DisplayName(this MessageLevel messageLevel)
        {
            string[] names = { "確認", "警告", "エラー" };
            return names[(int)messageLevel];
        }
    }
}
