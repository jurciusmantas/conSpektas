using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using System.Collections.Generic;

namespace conSpecktas.Model.Services.Conspects
{
    public interface IConspectsService
    {
        Conspect GetById(int id);
        ServerResult UploadConspect(UploadConspectArgs args);
        ServerResult<List<Conspect>> GetListPaged(GetConspectsListPagedArgs args);
        ServerResult DeleteConspect(int conspectId);
        ServerResult RateConspect(RateConspectArgs args);
    }
}