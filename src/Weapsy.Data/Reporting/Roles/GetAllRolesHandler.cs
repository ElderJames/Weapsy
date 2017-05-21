﻿using AutoMapper;
using Weapsy.Framework.Queries;
using System.Threading.Tasks;
using Weapsy.Reporting.Roles.Queries;
using System.Collections.Generic;
using Weapsy.Framework.Identity;
using Weapsy.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Weapsy.Data.Reporting.Roles
{
    public class GetAllRolesHandler : IQueryHandlerAsync<GetAllRoles, IEnumerable<Role>>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public GetAllRolesHandler(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Role>> RetrieveAsync(GetAllRoles query)
        {
            var result = _roleManager.Roles.ToList();

            result.Add(new Role
            {
                Id = Everyone.Id,
                Name = Everyone.Name
            });

            result.Add(new Role
            {
                Id = Registered.Id,
                Name = Registered.Name
            });

            result.Add(new Role
            {
                Id = Anonymous.Id,
                Name = Anonymous.Name
            });

            return result.OrderBy(x => x.Name).ToList();
        }
    }
}
