namespace WebBackend.Dtos.ProductionCompanies
{
    public class CreateProductionCompanyDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? LogoUrl { get; set; }
    }
}
