using conSpektas.Data.DTOs;

namespace conSpecktas.Model.Services.Conspects
{
    public interface IConspectsService
    {
        conSpektas.Data.Entities.Conspect GetById(int id);
        ServerResult UploadConspect(UploadConspectArgs args);
    }
}