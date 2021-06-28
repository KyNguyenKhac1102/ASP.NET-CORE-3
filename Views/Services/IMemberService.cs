using System;
using System.Collections.Generic;
using ASP_MVC_CORE.Models;

namespace ASP_MVC_CORE.Services{
    public interface IMemeberServices{
        List<Member> AllMembers();
        Member GetMemberById(Guid id);
        void Create(Member member);

        void Update(Member member);
        void Delete(Guid id);
    }
}