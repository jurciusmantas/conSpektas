﻿using conSpektas.Data.DTOs;

namespace conSpektas.Model.Services.Comments
{
    public interface ICommentService
    {
        ServerResult AddCommentToConspect(AddCommentToConspectArgs args);
    }
}