namespace OrderAccumulator.Utils
{
    ///********************************************************************
    ///
    ///           Nome: TextMessage.cs
    /// Funcionalidade: Mensagens para clientes
    /// 
    ///********************************************************************
    public static class TextMessage
    {
        public enum MsgCode
        {
            MsgInvalidAsset = 0,
            MsgMaxExposure = 1,
            MsgSuccess  = 2
        }

        private static readonly string[] _messages =
        {
            "Ativo {0} não encontrado",
            "Falha ao efetuar ordem, a requisição ultrapassa o nível máximo de exposição do ativo {0}",
            "Ordem efetuada com sucesso"
        };

        public static string GetText(MsgCode code, params object[] msgParams)
        {
            var index = (int)code;

            return string.Format(_messages[index], msgParams);
        }
    }
}
