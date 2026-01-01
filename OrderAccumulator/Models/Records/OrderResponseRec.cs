namespace OrderAccumulator.Models.Records
{
    public record OrderResponseRec(
        bool sucesso,
        decimal exposicao_atual,
        string msg
    );
}
