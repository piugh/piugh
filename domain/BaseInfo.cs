using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseInfo
    {
        private string _name;
        private string _createname;
        private DateTime _createtime;
        private string _aim;
        private string _remark;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string CreateName
        {
            get { return _createname; }
            set { _createname = value; }
        }
        public DateTime CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        public string Aim
        {
            get { return _aim; }
            set { _aim = value; }
        }
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
