﻿namespace cx.Application.Base.SystemModule
{
    /// <summary>
    /// 版 本 v1.0 辰星科技开发框架
    /// Copyright (c) 山西辰星昇软件科技有限公司
    /// 创建人：辰星-框架开发组
    /// 日 期：2018.03.04
    /// 描 述：数据库表模型
    /// </summary>
    public class DatabaseTableModel
    {
        /// <summary>
        /// 数据库表名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 数据库使用大小
        /// </summary>
        public string reserved { get; set; }
        /// <summary>
        /// 数据大小
        /// </summary>
        public string data { get; set; }
        /// <summary>
        /// 索引使用大小
        /// </summary>
        public string index_size { get; set; }
        /// <summary>
        /// 记录条数
        /// </summary>
        public int sumrows { get; set; }
        /// <summary>
        /// 未使用大小
        /// </summary>
        public string unused { get; set; }
        /// <summary>
        /// 表备注
        /// </summary>
        public string tdescription { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string pk { get; set; }
    }
}
