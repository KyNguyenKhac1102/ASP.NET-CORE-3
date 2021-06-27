using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASP_MVC_CORE.Models;

namespace ASP_CORE_MVC.Controllers
{
    public class MemberController : Controller
    {

        static List<Member> memberList = new List<Member>{
            new Member{Id = Guid.NewGuid(),
                        FirstName = "Ky",
                        LastName = "Nguyen Khac",
                        Gender = "Male",
                        DateOfBirth = new DateTime(1999, 11, 12),
                        PhoneNumber = "0222.222.222",
                        BirthPlace = "Ha Noi",
                        IsGraduated = false},
            new Member{Id = Guid.NewGuid(),
                        FirstName = "Trang",
                        LastName = "Huyen Nguyen",
                        Gender = "Female",
                        DateOfBirth = new DateTime(2002, 05, 21),
                        PhoneNumber = "0222.222.222",
                        BirthPlace = "Hai Phong",
                        IsGraduated = false},
            new Member{Id = Guid.NewGuid(),
                        FirstName = "Tuan",
                        LastName = "Trinh Dat",
                        Gender = "Male",
                        DateOfBirth = new DateTime(1994, 01, 15),
                        PhoneNumber = "0222.222.222",
                        BirthPlace = "Bac Ninh",
                        IsGraduated = false},
            new Member{Id = Guid.NewGuid(),
                        FirstName = "Cong",
                        LastName = "Nguyen Van",
                        Gender = "Male",
                        DateOfBirth = new DateTime(1996, 08, 12),
                        PhoneNumber = "0222.222.222",
                        BirthPlace = "Ha Noi",
                        IsGraduated = false},
            new Member{Id = Guid.NewGuid(),
                        FirstName = "Phuoc",
                        LastName = "Hoang Nhat",
                        Gender = "Male",
                        DateOfBirth = new DateTime(1998, 06, 18),
                        PhoneNumber = "0222.222.222",
                        BirthPlace = "Bac Ninh",
                        IsGraduated = false},
            new Member{Id = Guid.NewGuid(),
                        FirstName = "Long",
                        LastName = "Thang Bao",
                        Gender = "Male",
                        DateOfBirth = new DateTime(2000, 07, 12),
                        PhoneNumber = "0222.222.222",
                        BirthPlace = "Binh Duong",
                        IsGraduated = false},
        };

        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        
        
        public IActionResult Rookies(string sortBy){
            List<Member> list = new List<Member>();
            if(String.IsNullOrEmpty(sortBy)){
                list = memberList;
            }
            else if(sortBy == "Male"){
                list = memberList.Where(x => x.Gender == "Male").ToList();
            }
           
           return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            if(ModelState.IsValid){
                memberList.Add(member);
                return RedirectToAction("Rookies");
            }
           
            return View();
            
        }

        public  IActionResult Edit(Guid id)
        {
            var model = memberList.FirstOrDefault(x => x.Id == id);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Member member)
        {
            if(ModelState.IsValid){
                memberList.Remove(memberList.FirstOrDefault(x => x.Id == member.Id));
                memberList.Add(member);
                return RedirectToAction("Rookies");
            }

            return View(member);
        }

        public IActionResult Delete(Guid id){
            var model = memberList.FirstOrDefault(x => x.Id == id);
            memberList.Remove(model);
            return RedirectToAction("Rookies");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
