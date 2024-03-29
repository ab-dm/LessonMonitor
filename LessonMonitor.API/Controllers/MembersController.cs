﻿using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;

namespace LessonMonitor.API.Controllers
{
    /// <summary>
    /// Methods for interacting with member statistics
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MemberStatisticsController : ControllerBase
    {
        private readonly List<Member> _members;

        public MemberStatisticsController()
        {
            _members = new List<Member>()
            {
                new Member { Id = 1, UserName = "pingvin1308", FullName = "Роман" },
                new Member { Id = 2, UserName = "coder", FullName = "Михаил" },
                new Member { Id = 3, UserName = "eniluck", FullName = "Андрей" },
                new Member { Id = 4, UserName = "emedvedeva", FullName = "Евгения" },
                new Member { Id = 5, UserName = "kalilask4", FullName = "Диана" },
            };
        }

        [HttpGet]
        public ActionResult<MemberStatistics> Get(int memberId)
        {
            var member = _members.FirstOrDefault(x => x.Id.Equals(memberId));

            if (member == null)
                return NotFound("We can't find member with this id");

            return new MemberStatistics()
            {
                Member = member
            };
        }
    }
}
