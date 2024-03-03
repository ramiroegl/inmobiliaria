using Inmobiliaria.Domain.Shared;

namespace Inmobiliaria.Domain.Sales;

public class ServicesData : Entity
{
    public Guid SaleId { get; private init; }
    public Sale? Sale { get; private init; }
    public required Amount ElectricMeterValue { get; set; }
    public required bool InstalledElectricMeter { get; set; }
    public required bool InstalledWaterMeter { get; set; }
}
