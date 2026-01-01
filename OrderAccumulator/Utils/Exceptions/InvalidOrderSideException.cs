namespace OrderAccumulator.Utils.Exceptions
{
    public class InvalidOrderSideException : Exception
    {
        public InvalidOrderSideException(char side) : base($"Lado da ordem inválido, esperava-se C ou V, foi enviado: '{side}'") { }
    }
}
