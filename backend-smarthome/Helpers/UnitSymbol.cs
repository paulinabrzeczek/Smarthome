namespace backend_smarthome.Helpers
{
    public enum UnitSymbol
    {
        [UnitSymbol("°C")]
        DegreesCelsius = 1,

        [UnitSymbol("kW")]
        Kilowatts,

        [UnitSymbol("%")]
        Percent,

        [UnitSymbol("V")]
        Volts,
    }

    sealed class UnitSymbolAttribute : Attribute
    {
        public string Symbol { get; }

        public UnitSymbolAttribute(string symbol)
        {
            Symbol = symbol;
        }
    }
}
