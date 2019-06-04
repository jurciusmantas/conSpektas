using conSpektas.Data.DTOs;
using conSpektas.Data.Entities;
using System.Collections.Generic;

namespace conSpecktas.Model.Repositories.Conspects
{
    public interface IConspectsRepository
    {
        Conspect GetById(int id);
        int UploadConspect(Conspect item);
        List<Conspect> GetConspectsList(GetConspectsListPagedArgs args);
    }
}