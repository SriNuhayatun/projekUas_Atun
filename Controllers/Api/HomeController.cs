using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekUas_Atun.Helper;
using projekUas_Atun.Models;
using projekUas_Atun.Services.MemberServices;
using projekUas_Atun.Services.MobilServices;
using projekUas_Atun.Services.PaketServices;
using projekUas_Atun.Services.SupirServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace projekUas_Atun.Controllers.Api
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly IMemberServices _service;
        private readonly IMobilServices _serv;
        private readonly IPaketServices _servi;
        private readonly ISupirServices _servic;

        // class
        private BanyakBantuan _bantu = new BanyakBantuan();

        // tampungan objek
        private object _respon;
        private object _objek;

        // tampungan model
        private Member _TbMember;
        private Mobil _tbMobil;
        private Paket _tbPaket;
        private Supir _tbsupir;
     

        // tampungan string
        private string SMember = "Member";
        private string SMobil = "Mobil";
        private string SPaket = "Paket";
        private string Ssupir = "Supir";



        public HomeController(IMemberServices  s)
        {
            _service = s;
        }

        [Route("Member")]
        public IActionResult Member()
        {
            _objek = _service.TampilSemuaData();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SMember), _objek);
            return Ok(_respon);
        }

        [Route("Member")]
        [HttpPost]
        public IActionResult TambahMember( Member parameternya, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _service.BuatMember(parameternya, Image);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanTambahSukses(SMember), parameternya);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SMember), null);
            return Ok(_respon);
        }

        [Route("Member")]
        [HttpPut]
        public IActionResult UbahMember(Member parameternya, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _TbMember = _service.TampilMemberById(parameternya.Id_Member).Result;
                if (_TbMember != null)
                {
                    _service.UpdateMemberAsync(parameternya, Image);

                    _TbMember = _service.TampilMemberById(parameternya.Id_Member).Result;

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanUbahSukses(SMember), _TbMember);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SMember), null);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SMember), null);
            return Ok(_respon);
        }

        [Route("Member/{idnya}")]
        [HttpDelete]
        public IActionResult HapusMember(string idnya)
        {
            try
            {
                _TbMember = _service.TampilMemberById(idnya).Result;

                if (_TbMember != null)
                {
                    _service.HapusMember(idnya);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanHapusSukses(SMember), _TbMember);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SMember), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SMember), null);
                return Ok(_respon);
            }
        }

        [Route("Member/{idnya}")]
        public IActionResult DetailMember(string idnya)
        {
            _TbMember = _service.TampilMemberById(idnya).Result;

            if (_TbMember != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SMember), _TbMember);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SMember), null);
            return Ok(_respon);
        }
        //mobil

        [Route("Mobil/{idnya}")]
        public IActionResult DetailMobil(string idnya)
        {
            _tbMobil = _serv.TampilMobilById(idnya).Result;

            if (_tbMobil != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SMobil), _tbMobil);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SMobil), null);
            return Ok(_respon);
        }

        [Route("Mobil")]
        public IActionResult mobil()
        {
            _objek = _serv.TampilSemuaData();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SMobil), _objek);
            return Ok(_respon);
        }
        [Route("Paket/{idnya}")]
        public IActionResult DetaiPaket(string idnya)
        {
            _tbPaket = _servi.TampilPaketById(idnya).Result;

            if (_tbPaket != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SPaket), _tbPaket);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SPaket), null);
            return Ok(_respon);
        }

        [Route("Paket")]
        public IActionResult Paket()
        {
            _objek = _servi.TampilSemuaData();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(SPaket), _objek);
            return Ok(_respon);
        }
        [Route("Supir/{idnya}")]
        public IActionResult DetailSupir(string idnya)
        {
            _tbsupir = _servic.TampilSupirById(idnya).Result;

            if (_tbsupir != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(Ssupir), _tbsupir);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(Ssupir), null);
            return Ok(_respon);
        }

        [Route("Supir")]
        public IActionResult Supir()
        {
            _objek = _servic.TampilSemuaData();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOk, _bantu.PesanGetSukses(Ssupir), _objek);
            return Ok(_respon);
        }


    }
}
