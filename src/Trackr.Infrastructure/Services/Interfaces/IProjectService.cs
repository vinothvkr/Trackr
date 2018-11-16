using System;
using System.Collections.Generic;
using System.Text;
using Trackr.Infrastructure.Models;

namespace Trackr.Infrastructure.Services
{
    public interface IProjectService : IService<Project>
    {
        Project Get(int id);
    }
}
