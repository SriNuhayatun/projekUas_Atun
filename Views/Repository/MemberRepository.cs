using Microsoft.EntityFrameworkCore;
using projekUas_Atun.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Repository
{
    public class MemberRepository:IMemberRepository
    {
        private readonly AppDbContext _MemberDB;

        public MemberRepository(AppDbContext b)
        {
            _MemberDB = b;
        }

        public async Task<bool> BuatMemberAsync(Member datanya)
        {
            _MemberDB.Tb_Member.Add(datanya);
            await _MemberDB.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HapusMemberAsync(Member datanya)
        {
            _MemberDB.Tb_Member.Remove(datanya);
            await _MemberDB.SaveChangesAsync();
            return true;
        }

        public async Task<Member> TampilMemberByIDAsync(string id)
        {
            return await _MemberDB.Tb_Member.FirstOrDefaultAsync(x => x.Id_Member == id);
        }

        public async Task<List<Member>> TampilSemuaMemberAsync()
        {
            var data = await _MemberDB.Tb_Member.ToListAsync();
            return data;
        }

        public async Task<bool> UpdateMemberAsync(Member datanya)
        {
            _MemberDB.Tb_Member.Update(datanya);
            await _MemberDB.SaveChangesAsync();
            return true;
        }
    }
}
