using Microsoft.AspNetCore.Http;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Services.MemberServices
{
    public interface IMemberServices
    {
        List<Member> TampilSemuaData();
        Task<Member> TampilMemberById(string id);
        Task<bool> BuatMember(Member datanya, IFormFile Fotonya);
        Task<bool> HapusMember(string id);
        Task<bool> UpdateMemberAsync(Member datanya);
    }
}
