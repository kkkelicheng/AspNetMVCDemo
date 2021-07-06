using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemoView.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Account { get; set; }
        public string NickName { get; set; }
        public DateTime Birthday { get; set; }
        public bool Sex { get; set; }
        public string Hobby { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
    }
}