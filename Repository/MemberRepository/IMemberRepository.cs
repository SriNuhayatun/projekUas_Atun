using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Repository.MemberRepository
{
    public interface IMemberRepository
    {
        Task<bool> BuatMemberAsync(Member datanya);
        Task<List<Member>> TampilSemuaMemberAsync();
        Task<Member> TampilMemberByIDAsync(string id);
        Task<bool> UpdateMemberAsync(Member datanya);
        Task<bool> HapusMemberAsync(Member datanya);
    }
}
