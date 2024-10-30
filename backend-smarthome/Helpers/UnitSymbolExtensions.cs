namespace backend_smarthome.Helpers
{
    public static class UnitSymbolExtensions
    {
        public static string GetSymbol(this UnitSymbol unit)
        {
            var type = unit.GetType();
            var memInfo = type.GetMember(unit.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(UnitSymbolAttribute), false);
            return ((UnitSymbolAttribute)attributes[0]).Symbol;
        }

        public static string GetSymbolByDeviceTypeId(int deviceTypeId)
        {
            return deviceTypeId switch
            {
                1 => UnitSymbol.DegreesCelsius.GetSymbol(),
                2 => UnitSymbol.Kilowatts.GetSymbol(),
                3 => UnitSymbol.Percent.GetSymbol(),
                4 => UnitSymbol.Percent.GetSymbol(),  
                5 => UnitSymbol.DegreesCelsius.GetSymbol(),
                6 => UnitSymbol.Volts.GetSymbol(),          
                _ => string.Empty
            };
        }
    }
}
