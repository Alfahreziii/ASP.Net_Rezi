namespace FakultasApi.DTOs
{
    public class CreateFakultasDto
    {
        public string NamaFakultas { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateFakultasDto
    {
        public string NamaFakultas { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}