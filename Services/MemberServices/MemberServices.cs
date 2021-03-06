using Microsoft.AspNetCore.Http;
using projekUas_Atun.Models;
using projekUas_Atun.Repository.MemberRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekUas_Atun.Services.MemberServices
{
    public class MemberServices : IMemberServices
    {
        private readonly IMemberRepository _memRepo;
        private readonly FileServices _file;

        public MemberServices(IMemberRepository r, FileServices f)
        {
            _memRepo = r;
            _file = f;

        }

        public Task<bool> BuatMember(Member datanya, IFormFile Fotonya)
        {

            datanya.Image = _file.SimpanFile(Fotonya).Result;

            return _memRepo.BuatMemberAsync(datanya);
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

        public List<Member> TampilSemuaData()
        {
            return _memRepo.TampilSemuaMemberAsync().Result;
        }

        public async Task<bool> UpdateMemberAsync(Member datanya, IFormFile Fotonya)
        {
            var cari = _memRepo.TampilMemberByIDAsync(datanya.Id_Member).Result;
            if (cari != null)
            {
                cari.NamaMember = datanya.NamaMember;
                cari.JenisKelamin = datanya.JenisKelamin;
                cari.Alamat = datanya.Alamat;
               

                if (Fotonya != null) cari.Image =await _file.SimpanFile(Fotonya);
                else cari.Image = cari.Image;
                return await _memRepo.UpdateMemberAsync(cari);
            }
            return false;

        }
    }
}
