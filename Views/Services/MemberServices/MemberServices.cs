using Microsoft.AspNetCore.Http;
using projekUas_Atun.Models;
using projekUas_Atun.Views.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Views.Services.MemberServices
{
    public class MemberServices : IMemberServices
    {
        private readonly IMemberRepository _memRepo;
        private readonly FileService _file;

        public MemberServices(IMemberRepository r, FileService f)
        {
            _memRepo = r;
            _file = f;

        }

        public  Task<bool> BuatMember(Member datanya, IFormFile Fotonya)
        {

            datanya.Image =  _file.SimpanFile(Fotonya).Result;

            return  _memRepo.BuatMemberAsync(datanya);
        }

        public async Task<bool> HapusMember(string id)
        {
            var cari = await _memRepo.TampilMemberByIDAsync(id);
            await _memRepo.HapusMemberAsync(cari);
            return true;
        }

        public async Task<Member> TampilMemberById(string id)
        {
            return await _memRepo.TampilMemberByIDAsync(id);
        }

        public async Task<List<Member>> TampilSemuaData()
        {
            return await _memRepo.TampilSemuaMemberAsync();
        }

        public async Task<bool> UpdateMemberAsync(Member datanya)
        {
            return await _memRepo.UpdateMemberAsync(datanya);

        }
       
    }
}
