using PMSystem.Shared;

namespace PMSystem.Client.Services.PartsService
{
    public interface IPartsService
    {
        Task<ServiceResponse<List<PartsModel>>> GetParts();

        Task<ServiceResponse<string>> AddParts(AddPartsModel parts);

        Task<ServiceResponse<string>> DeleteParts(int id);

        Task<ServiceResponse<string>> UpdateParts(UpdatePartsModel parts);
    }
}
