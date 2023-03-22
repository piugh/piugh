using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Agent : Data
    {
        public virtual int id { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public virtual string Gender { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public virtual int Age { get; set; }
        /// <summary>
        /// 年龄分段
        /// </summary>
        public virtual AgeLevel AgeLevel { get; set; }
        /// <summary>
        /// 受教育程度
        /// </summary>
        public virtual EduLevel EduLevel { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public virtual Occupation Occupation { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public virtual int Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public virtual int Latitude { get; set; }
        /// <summary>
        /// 所属个体集
        /// </summary>
        public virtual AgentSet AgentSet { get; set; }
    }
}
