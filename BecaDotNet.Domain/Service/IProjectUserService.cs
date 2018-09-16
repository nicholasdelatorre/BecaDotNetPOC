using BecaDotNet.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BecaDotNet.Domain.Service {
    public interface IProjectUserService {

        ProjetcUser StartProject(ProjetcUser project, ProjetcUser user);

    }
}
