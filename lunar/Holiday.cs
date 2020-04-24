using System;
using System.Collections.Generic;
using System.Text;

namespace com.nlf.calendar
{
    /// <summary>
    /// 节假日
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// 日期，YYYY-MM-DD
        /// </summary>
        private string day;

        /// <summary>
        /// 名称，如：国庆节
        /// </summary>
        private string name;

        /// <summary>
        /// 是否调休，即是否要上班
        /// </summary>
        private bool work;

        /// <summary>
        /// 关联的节日，YYYY-MM-DD格式
        /// </summary>
        private string target;

        public Holiday() { }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="day">日期</param>
        /// <param name="name">名称</param>
        /// <param name="work">是否调休</param>
        /// <param name="target">关联的节日</param>
        public Holiday(string day, string name, bool work, string target)
        {
            if (!day.Contains("-"))
            {
                this.day = day.Substring(0, 4) + "-" + day.Substring(4, 2) + "-" + day.Substring(6);
            }
            else
            {
                this.day = day;
            }
            this.name = name;
            this.work = work;
            if (!target.Contains("-"))
            {
                this.target = target.Substring(0, 4) + "-" + target.Substring(4, 2) + "-" + target.Substring(6);
            }
            else
            {
                this.target = target;
            }
        }

        /// <summary>
        /// 获取日期
        /// </summary>
        /// <returns>日期，YYYY-MM-DD</returns>
        public string getDay()
        {
            return day;
        }

        /// <summary>
        /// 设置日期
        /// </summary>
        /// <param name="day">日期，YYYY-MM-DD</param>
        public void setDay(string day)
        {
            this.day = day;
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        /// <returns>名称</returns>
        public string getName()
        {
            return name;
        }

        /// <summary>
        /// 设置名称
        /// </summary>
        /// <param name="name">名称</param>
        public void setName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// 是否调休
        /// </summary>
        /// <returns>true/false</returns>
        public bool isWork()
        {
            return work;
        }

        /// <summary>
        /// 设置调休
        /// </summary>
        /// <param name="work">true/false</param>
        public void setWork(bool work)
        {
            this.work = work;
        }

        /// <summary>
        /// 获取关联的节日
        /// </summary>
        /// <returns>节日日期，YYYY-MM-DD</returns>
        public string getTarget()
        {
            return target;
        }

        /// <summary>
        /// 设置关联的节日
        /// </summary>
        /// <param name="target">节日日期，YYYY-MM-DD</param>
        public void setTarget(string target)
        {
            this.target = target;
        }


        public override string ToString()
        {
            return day + " " + name + (work ? "调休" : "") + " " + target;
        }
    }
}